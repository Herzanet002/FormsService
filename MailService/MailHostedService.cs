using MailKit.Net.Imap;
using MailService.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace MailService
{
    public interface IMailHostedService
    {

    }
    public class MailHostedService : BackgroundService, IMailHostedService
    {
        private readonly ILogger<MailHostedService> _logger;
        private readonly IServiceProvider _services;
        //private readonly MailServiceClient _mailServiceClient;
        private readonly ClientSettings _clientSettings;
        private readonly IOptionsMonitor<ClientSettings> _optionsDelegate;
        public MailHostedService(ILogger<MailHostedService> logger, IServiceProvider services, IOptionsMonitor<ClientSettings> optionsDelegate)
        {
            _logger = logger;
            _services = services;
            _optionsDelegate = optionsDelegate;
            //_mailServiceClient = services.GetRequiredService<MailServiceClient>();
            _optionsDelegate = optionsDelegate;
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
                //using var scope = _services.CreateScope();
                var mailServiceClient = _services.GetRequiredService<IMailServiceClient>();
                mailServiceClient.Init(_clientSettings);
                await mailServiceClient.ReceiveEmail();
                await Task.Delay(TimeSpan.FromSeconds(_clientSettings.EmailReadInterval), stoppingToken);

                _logger.LogInformation("Reading letters started");
            } while (!stoppingToken.IsCancellationRequested);


        }
    }
}
