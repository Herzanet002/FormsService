using MailService.Configurations;
using MailService.Services;
using MailService.Services.Hosted;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MailService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureMailService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<ClientSettings>(
                configuration.GetSection(nameof(IMapClientConfigurations)));
            return services;
        }

        public static IServiceCollection AddMailHostedService(this IServiceCollection services)
        {
            services.AddHostedService<MailHostedService>();
            return services;
        }

        public static IServiceCollection AddEmailService(this IServiceCollection services)
        {
            services.AddTransient<IMailServiceClient, MailServiceClient>();
            return services;
        }
    }
}