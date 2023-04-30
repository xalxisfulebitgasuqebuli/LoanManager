using IdentityServer;
using IdentityServer.Data;
using IdentityServer.Models;
using IdentityServer.STS;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var seed = args.Contains("/seed");
if (seed)
    args = args.Except(new[] { "/seed" }).ToArray();

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly.GetName().Name;
var defaultConnection = builder.Configuration.GetConnectionString("Default");


if (seed)
{
    SeedData.EnsureSeedData(defaultConnection);
}

builder.Services.AddDbContext<AspNetIdentityDbContext>(options =>
    options.UseSqlServer(defaultConnection, sql => sql.MigrationsAssembly(assembly)));

builder.Services.AddIdentity<CustomIdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AspNetIdentityDbContext>();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<CustomIdentityUser>()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b =>
            b.UseSqlServer(defaultConnection, sql => sql.MigrationsAssembly(assembly));
    })
    .AddOperationalStore(opt =>
    {
        opt.ConfigureDbContext = b =>
                    b.UseSqlServer(defaultConnection, sql => sql.MigrationsAssembly(assembly));
    })
    .AddDeveloperSigningCredential()
    .AddProfileService<LoansManagerProfileService>()
    .AddCustomTokenRequestValidator<CustomTokenRequestValidator>()
    .AddCustomAuthorizeRequestValidator<CustomAuthorizedRequestValidator>();



builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization();

builder.Services.AddControllers();


var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.UseAuthentication();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
