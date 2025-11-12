//using CreditService.Application.Services;
using CreditService.Domain;
using CreditService.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CreditService.Application.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Register business logic services
            services.AddScoped<ICreditService, CreditService>();

            // Optional: Add AutoMapper, FluentValidation, etc.
            // services.AddAutoMapper(typeof(MappingProfile));
            // services.AddValidatorsFromAssemblyContaining<CreditValidator>();

            return services;
        }
    }
}
