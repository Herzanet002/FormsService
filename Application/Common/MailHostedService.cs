using Application.Common.Configurations;
using Application.Interfaces.Services;
using MailService.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Application.Common;

public class MailHostedService : BackgroundService
{
	private readonly ClientSettings _clientSettings;
	private readonly FormsConfiguration _formsConfiguration;
	private readonly ILogger<MailHostedService> _logger;
	private readonly IServiceProvider _services;
	private IImapClient? _mailServiceClient;

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
		if (!_clientSettings.IsActive) return Task.CompletedTask;
		_mailServiceClient = _services.GetRequiredService<IImapClient>();
		_mailServiceClient.InitializeClient(_clientSettings, _formsConfiguration);
		_logger.LogInformation($"{nameof(MailHostedService)} started");

		return base.StartAsync(cancellationToken);
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		if(_mailServiceClient is null)
			throw new NullReferenceException("IMapClient is not initialized");
		do
		{
			await _mailServiceClient.ReceiveItemsAsync();
			await Task.Delay(TimeSpan.FromSeconds(_clientSettings.EmailReadInterval), stoppingToken);
		} while (!stoppingToken.IsCancellationRequested);
	}
}