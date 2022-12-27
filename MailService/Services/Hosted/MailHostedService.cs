using MailService.Configurations;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MailService.Services.Hosted;

public class MailHostedService : BackgroundService
{
    private readonly ClientSettings _clientSettings;
    private readonly FormsConfiguration _formsConfiguration;
    private readonly ILogger<MailHostedService> _logger;
    private readonly IServiceProvider _services;

    public MailHostedService(ILogger<MailHostedService> logger,
        IServiceProvider services,
        IOptionsMonitor<ClientSettings> clientSettings,
        IOptionsMonitor<FormsConfiguration> formsConfiguration)
    {
        _logger = logger;
        _services = services;
        _formsConfiguration = formsConfiguration.CurrentValue;
        _clientSettings = clientSettings.CurrentValue;
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
            //var mailServiceClient = _services.GetRequiredService<IImapClient>();
            //mailServiceClient.InitializeClient(_clientSettings, _formsConfiguration);

            //await mailServiceClient.ReceiveItem();
            await Task.Delay(TimeSpan.FromSeconds(_clientSettings.EmailReadInterval), stoppingToken);
        } while (!stoppingToken.IsCancellationRequested);
    }
}