using MailService.Configurations;
using MailService.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
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
	private IImapClient? mailServiceClient;

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
		mailServiceClient = _services.GetRequiredService<IImapClient>();
		mailServiceClient.InitializeClient(_clientSettings, _formsConfiguration);
		_logger.LogInformation($"{nameof(MailHostedService)} started");

		return base.StartAsync(cancellationToken);
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		if (!_clientSettings.IsActive) return;
		if(mailServiceClient is null)
			throw new NullReferenceException("IMapClient is not initialized");
		do
		{
			await mailServiceClient.ReceiveItemsAsync();
			await Task.Delay(TimeSpan.FromSeconds(_clientSettings.EmailReadInterval), stoppingToken);
		} while (!stoppingToken.IsCancellationRequested);
	}
}