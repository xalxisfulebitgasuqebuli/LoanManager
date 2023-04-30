using LoanManager.Domain.Entities.User;
using LoanManager.Repository.DataBase;
using LoanManager.Repository.Repositories;
using LoanManager.Service.Abstraction;
using LoanManager.Service.Loans.Commands;
using LoanManager.Web.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LoanManager.Web.Extensions
{
    public static class MinimalApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            //builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<LoanDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.Authority = "https://localhost:7283";
                    options.ApiName = "LoanManager";
                });
            builder.Services.AddAuthorization();

            builder.Services.AddScoped<ILoanRepository, LoanRepository>();

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(CreateLoan).Assembly);
            });
        }

    }
}
