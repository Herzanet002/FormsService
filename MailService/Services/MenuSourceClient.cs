using Domain.Entities;
using Domain.Interfaces.Repositories;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailService.Configurations;
using MailService.Helpers;
using MailService.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MimeKit;
using System.Text.Json;
using IImapClient = MailService.Services.Interfaces.IImapClient;

namespace MailService.Services;

public class MenuSourceClient : IImapClient
{
	private readonly ImapClient _imapClient;
	private readonly ILogger<MenuSourceClient> _logger;
	private readonly IServiceProvider _serviceProvider;

	private ClientSettings? _clientSettings;
	private FormsConfiguration? _formsConfiguration;

	public MenuSourceClient(ILogger<MenuSourceClient> logger, IServiceProvider serviceProvider)
	{
		_logger = logger;
		_serviceProvider = serviceProvider;
		_imapClient = new ImapClient();
	}

	public void InitializeClient(ClientSettings clientSettings, FormsConfiguration formsConfiguration)
	{
		_clientSettings = clientSettings;
		_formsConfiguration = formsConfiguration;
	}

	public async Task<List<MessageModel>> ReceiveItemsAsync()
	{
		await ConnectAsync();
		await AuthenticateAsync();

		var inboxFolder = _imapClient.Inbox;
		var messages = new List<MessageModel>();
		var inboxMessages = await inboxFolder.FetchAsync(
			await inboxFolder.SearchAsync(SearchQuery.All, CancellationToken.None),
			MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure | MessageSummaryItems.Envelope);

		using var scope = _serviceProvider.CreateScope();
		var ordersRepository = scope.ServiceProvider.GetService<IOrderRepository>() ??
							   throw new NullReferenceException($"{nameof(IOrderRepository)} is null");
		var personsRepository = scope.ServiceProvider.GetService<IPersonRepository>() ??
								throw new NullReferenceException($"{nameof(IPersonRepository)} is null");
		var dishesRepository = scope.ServiceProvider.GetService<IDishRepository>() ??
							   throw new NullReferenceException($"{nameof(IDishRepository)} is null");

		foreach (var message in inboxMessages)
		{
			if (!MessageValidation(message)) continue;

			if (await inboxFolder.GetBodyPartAsync(message.UniqueId, message.HtmlBody) is not TextPart body) continue;

			var messageModel = new MessageModel
			{
				UniqueId = message.UniqueId,
				Content = body.Text.GetJsonFromHtml(),
				From = message.Envelope.From.ToString(),
				Subject = message.Envelope.Subject,
				Date = message.Envelope.Date!.Value
			};

			var menuModel = GetItemInfo(messageModel.Content);
			if (menuModel is null)
			{
				_logger.LogWarning("Message is nullable");
				continue;
			}

			_logger.LogInformation(
				$"Message in inbox folder: UniqID: {messageModel.UniqueId}, sent: {messageModel.Date}");
			messages.Add(messageModel);

			var person = personsRepository.GetByFilter(p => p.Name == menuModel.Person.Name).FirstOrDefault();

			if (person is null) continue;

			ICollection<Dish> listOfDishes = menuModel.Dishes
				.Where(containingDish => containingDish != null)
				.Select(dish => dishesRepository.GetByFilter(x => x.Name == dish.Name)
					.FirstOrDefault())
				.ToList()!;

			var order = new Order
			{
				Dishes = listOfDishes,
				DateForming = message.Date.UtcDateTime,
				Person = person,
				Location = menuModel.Location
			};

			if (ordersRepository
				.GetByFilter(o => o.DateForming == order.DateForming && o.Person.Name == order.Person.Name)
				.Any()) continue;
			var query = await ordersRepository.PreCommit(order);
			foreach (var dish in menuModel.Dishes.Where(_ => query.DishOrders != null))
				if (query.DishOrders != null)
					query.DishOrders.Single(x => x.Dish.Name == dish.Name).Price = dish.Price;

			await ordersRepository.Add(query);

			//await MarkItemAsProcessed(message.UniqueId);
		}

		//await _imapClient.Inbox.ExpungeAsync();
		return messages;
	}

	public Task MarkItemAsProcessed(UniqueId uid)
	{
		return _imapClient.Inbox.AddFlagsAsync(new[] { uid }, MessageFlags.Deleted, true);
	}

	private async Task ConnectAsync()
	{
		if (_imapClient.IsConnected) return;
		using var cancelTokenSource = new CancellationTokenSource();
		var cancellationToken = cancelTokenSource.Token;
		if (_clientSettings == null)
			throw new NullReferenceException(nameof(_clientSettings));
		try
		{
			await _imapClient.ConnectAsync(_clientSettings.Host, _clientSettings.Port, _clientSettings.Ssl,
				cancellationToken);
			_logger.LogInformation(
				$"Connection successfully to mail server : {_clientSettings.Host}:{_clientSettings.Port}");
		}
		catch (Exception e)
		{
			_logger.LogError(e,
				$"An error when connecting to mail server: {_clientSettings.Host}:{_clientSettings.Port}");
			throw;
		}
	}

	private async Task AuthenticateAsync()
	{
		if(_imapClient.IsAuthenticated) return;
		using var cancelTokenSource = new CancellationTokenSource();
		var cancellationToken = cancelTokenSource.Token;
		if (_clientSettings == null)
			throw new NullReferenceException(nameof(_clientSettings));
		try
		{
			await _imapClient.AuthenticateAsync(_clientSettings.Login, _clientSettings.Password, cancellationToken);
			await _imapClient.Inbox.OpenAsync(FolderAccess.ReadWrite, cancellationToken);
			_logger.LogInformation($"Authenication successfully : {_clientSettings.Host}:{_clientSettings.Port}");
		}
		catch (Exception e)
		{
			_logger.LogError(e,
				$"An error when authenticate to mail server: {_clientSettings.Host}:{_clientSettings.Port}");
			throw;
		}
	}

	private static MenuModel? GetItemInfo(string jsonString)
	{
		return string.IsNullOrWhiteSpace(jsonString)
			? null
			: JsonSerializer.Deserialize<MenuModel>(jsonString);
	}

	private bool MessageValidation(IMessageSummary message)
	{
		if (_formsConfiguration == null)
			throw new NullReferenceException(nameof(_formsConfiguration));

		return message.Envelope.Subject == _formsConfiguration.Subject &&
			   message.Envelope.From.Any(address => address.Name == _formsConfiguration.Service) &&
			   message.Envelope.From.Mailboxes.All(x => x.Domain == _formsConfiguration.Domain);
	}
}