using IdentityModel;
using IdentityServer.Data;
using IdentityServer.Models;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.EntityFramework.Storage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace IdentityServer
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<AspNetIdentityDbContext>(options =>
                           options.UseSqlServer(connectionString));

            services
                .AddIdentity<CustomIdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AspNetIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddOperationalDbContext(
                options =>
                {
                    options.ConfigureDbContext = b =>
                        b.UseSqlServer(connectionString,
                            sql => sql.MigrationsAssembly(typeof(SeedData).Assembly.FullName));
                });

            services.AddConfigurationDbContext(
                options =>
                {
                    options.ConfigureDbContext = b =>
                        b.UseSqlServer(connectionString,
                            sql => sql.MigrationsAssembly(typeof(SeedData).Assembly.FullName));
                });

            var serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            scope.ServiceProvider.GetService<PersistedGrantDbContext>().Database.Migrate();

            var context = scope.ServiceProvider.GetService<ConfigurationDbContext>();
            context.Database.Migrate();

            EnsureSeedData(context);

            var ctx = scope.ServiceProvider.GetService<AspNetIdentityDbContext>();
            ctx.Database.Migrate();
            EnsureUsers(scope);
        }

        private static void EnsureUsers(IServiceScope scope)
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<CustomIdentityUser>>();

            var angella = userManager.FindByNameAsync("angella").Result;
            if (angella == null)
            {
                angella = new CustomIdentityUser
                {
                    BirthDate = DateTime.Now,
                    FirstName = "Angella",
                    LastName = "Freeman",
                    PersonalId = "123456789",
                    UserName = "angella",
                    Email = "angella.freeman@email.com",
                    EmailConfirmed = true
                    
                };
                var result = userManager.CreateAsync(angella, "Pass123$").Result;
                if(!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result =
                    userManager.AddClaimsAsync(
                        angella,
                        new Claim[]
                        {
                            new Claim(JwtClaimTypes.BirthDate, angella.BirthDate.ToShortDateString()),
                            new Claim("personal_id", angella.PersonalId),
                            new Claim(JwtClaimTypes.Subject, angella.Id),
                            new Claim(JwtClaimTypes.Name, $"{angella.FirstName} {angella.LastName}"),
                            new Claim(JwtClaimTypes.GivenName, angella.FirstName),
                            new Claim(JwtClaimTypes.FamilyName, angella.LastName),
                            new Claim(JwtClaimTypes.WebSite, "https://angellafreeman.com"),
                            new Claim("location", "somewhere")
                        }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
            }
        }

        private static void EnsureSeedData(ConfigurationDbContext context)
        {
            if (!context.Clients.Any())
            {
                foreach (var client in Config.Clients.ToList())
                {
                    context.Clients.Add(client.ToEntity());
                }

                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in Config.IdentityResources.ToList())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }

                context.SaveChanges();
            }

            if (!context.ApiScopes.Any())
            {
                foreach (var resource in Config.ApiScopes.ToList())
                {
                    context.ApiScopes.Add(resource.ToEntity());
                }

                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in Config.ApiResources.ToList())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }

                context.SaveChanges();
            }
        }
    }
}
