using MailService.Configurations;
using MailService.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MailService.Services.Hosted
{
    public class MailHostedService : BackgroundService
    {
        private readonly ILogger<MailHostedService> _logger;
        private readonly IServiceProvider _services;
        private readonly ClientSettings _clientSettings;
        //dbRepository

        public MailHostedService(ILogger<MailHostedService> logger,
            IServiceProvider services,
            IOptionsMonitor<ClientSettings> optionsDelegate)
        {
            _logger = logger;
            _services = services;
            _clientSettings = optionsDelegate.CurrentValue;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(MailHostedService)} stopped");
            return base.StopAsync(cancellationToken);
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(MailHostedService)} started");

            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var mailServiceClient = _services.GetRequiredService<IImapClient>();
                mailServiceClient.InitializeClient(_clientSettings);

                await mailServiceClient.ReceiveItem();
                await Task.Delay(TimeSpan.FromSeconds(_clientSettings.EmailReadInterval), stoppingToken);
            } while (!stoppingToken.IsCancellationRequested);
        }
    }
}