using CreditService.Domain.Interfaces;
using CreditService.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Caching;
using StackExchange.Redis;
using Microsoft.EntityFrameworkCore;
namespace CreditService.Infrastructure.Extensions
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // SQL DbContext
            services.AddDbContext<SqlDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlDb")));

            // Repository
            services.AddScoped<ICreditRepository, CreditRepository>();

            // Redis Cache
            services.AddSingleton<IConnectionMultiplexer>(
                ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")));

            services.AddScoped<ICacheProvider, RedisCacheProvider>();

            // Optional: Azure Key Vault, Service Bus, etc.
            // services.AddScoped<ISecretProvider, KeyVaultProvider>();
            // services.AddSingleton<IServiceBusPublisher, ServiceBusPublisher>();

            return services;
        }
    }
}
