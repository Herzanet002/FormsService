using MailService.Configurations;
using MailService.Services;
using MailService.Services.Hosted;
using MailService.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MailService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureIMapService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<ClientSettings>(
                configuration.GetSection(nameof(IMapClientConfigurations)));
            return services;
        }

        public static IServiceCollection ConfigureFormsService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<FormsConfiguration>(
                configuration.GetSection(nameof(FormsConfiguration)));
            return services;
        }

        public static IServiceCollection AddMailHostedService(this IServiceCollection services)
        {
            services.AddHostedService<MailHostedService>();
            return services;
        }

        public static IServiceCollection AddIMapClientService(this IServiceCollection services)
        {
            services.AddTransient<IImapClient, MenuSourceClient>();
            return services;
        }
    }
}