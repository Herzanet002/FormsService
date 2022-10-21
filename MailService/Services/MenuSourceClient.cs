using FormsService.DAL.Entities;
using FormsService.DAL.Repository.Interfaces;
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

    public MenuSourceClient(ILogger<MenuSourceClient> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _imapClient = new ImapClient();
    }

    public void InitializeClient(ClientSettings clientSettings)
    {
        _clientSettings = clientSettings;
    }

    public async Task<List<MessageModel>> ReceiveItem()
    {
        await ConnectAsync();
        await AuthenticateAsync();

        var inboxFolder = _imapClient.Inbox;
        var messages = new List<MessageModel>();
        var inboxMessages = await inboxFolder.FetchAsync(
            await inboxFolder.SearchAsync(SearchQuery.All, CancellationToken.None),
            MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure | MessageSummaryItems.Envelope);

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

            var menuModel = GetItemInfo(messageModel);
            if (menuModel is null)
            {
                _logger.LogWarning("Message is nullable");
                continue;
            }

            _logger.LogInformation(
                $"Message in inbox folder: UniqID: {messageModel.UniqueId}, sent: {messageModel.Date}, contains:{menuModel}");
            messages.Add(messageModel);

            using var scope = _serviceProvider.CreateScope();
            var ordersRepository = scope.ServiceProvider.GetService<IRepository<Order>>() ?? throw new NullReferenceException($"{nameof(IRepository<Order>)} is null");
            var personsRepository = scope.ServiceProvider.GetService<IRepository<Person>>() ?? throw new NullReferenceException($"{nameof(IRepository<Person>)} is null");
            var dishesRepository = scope.ServiceProvider.GetService<IRepository<Dish>>() ?? throw new NullReferenceException($"{nameof(IRepository<Dish>)} is null");

            var person = personsRepository.GetByPredicate(p => p.Name == menuModel.Person.Name).FirstOrDefault();

            if (person is null) continue;

            var listOfDishes = menuModel.Dishes
                .Select(dish => dishesRepository.GetByPredicate(x => x.Name == dish.Name)
                .FirstOrDefault())
                .Where(containingDish => containingDish != null)
                .ToList();

            var order = new Order
            {
                Dishes = listOfDishes,
                DateForming = message.Date.UtcDateTime,
                Person = person,
                Location = menuModel.Location == "Заберу с собой" ? Location.WithMe : Location.InCafe
            };

            if (ordersRepository.GetByPredicate(o => o.DateForming == order.DateForming && o.Person.Name == order.Person.Name)
                .Any()) continue;
            var query = await ordersRepository.AddWithoutSaving(order);
            foreach (var dish in menuModel.Dishes.Where(_ => query.DishOrders != null))
            {
                if (query.DishOrders != null)
                    query.DishOrders.Single(x => x.Dish.Name == dish.Name).Price = dish.Price;
            }

            await ordersRepository.Add(query);

            //await MarkItemAsProcessed(message.UniqueId);
        }

        //await _imapClient.Inbox.ExpungeAsync();
        return messages;
    }

    public async Task MarkItemAsProcessed(UniqueId uid)
    {
        await _imapClient.Inbox.AddFlagsAsync(new[] { uid }, MessageFlags.Deleted, true);
    }

    public async Task ConnectAsync()
    {
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

    public async Task AuthenticateAsync()
    {
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

    public MenuModel? GetItemInfo(MessageModel message)
    {
        return string.IsNullOrWhiteSpace(message.Content)
            ? null
            : JsonSerializer.Deserialize<MenuModel>(message.Content);
    }

    private static bool MessageValidation(IMessageSummary message)
    {
        return message.Envelope.Subject == "FormReply" &&
               message.Envelope.From.Mailboxes.All(x => x.Domain == "forms-mailer.yaconnect.com");
    }
}