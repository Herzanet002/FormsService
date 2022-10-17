using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailService.Configurations;
using MailService.Helpers;
using MailService.Models;
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

    public async Task ConnectAsync()
    {
        using var cancelTokenSource = new CancellationTokenSource();
        var cancellationToken = cancelTokenSource.Token;
        if (_clientSettings == null)
            throw new NullReferenceException(nameof(_clientSettings));
        try
        {
            await _imapClient.ConnectAsync(_clientSettings.Host, _clientSettings.Port, _clientSettings.Ssl, cancellationToken);
            _logger.LogInformation($"Connection successfully to mail server : {_clientSettings.Host}:{_clientSettings.Port}");
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"An error when connecting to mail server: {_clientSettings.Host}:{_clientSettings.Port}");
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
            _logger.LogError(e, $"An error when authenticate to mail server: {_clientSettings.Host}:{_clientSettings.Port}");
            throw;
        }
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
            var menuModel = GetItemInfo(messageModel)!;

            //using var scope = _serviceProvider.CreateScope();
            //var ordersRepository = scope.ServiceProvider.GetService<IRepository<Order>>();
            //var personsRepository = scope.ServiceProvider.GetService<IRepository<Person>>();
            //if (ordersRepository is null) throw new NullReferenceException(nameof(ordersRepository));
            //if (menuModel == null) continue;
            //var byPredicate = personsRepository.GetByPredicate(p => p.Name == menuModel.Person.Name);
            //var listOfDishes = new List<Dish>
            //{
            //    menuModel.Soup!,
            //    menuModel.Salad!,
            //    menuModel.FirstCourse!
            //}.Where(d => d is { }).ToList();

            //var order = new Order
            //{
            //    Dishes = listOfDishes,
            //    DateForming = message.Date.UtcDateTime,
            //    Person = menuModel.Person, //
            //    Location = menuModel.Location == "Возьму с собой" ? Location.WithMe : Location.InCafe
            //};

            //await ordersRepository.Add(order);
            _logger.LogInformation($"Message in inbox folder: UniqID: {messageModel.UniqueId}, sent: {messageModel.Date}," +
                                   $" contains:{menuModel}");
            messages.Add(messageModel);
            //await MarkItemAsProcessed(message.UniqueId);
        }
        //await _imapClient.Inbox.ExpungeAsync();
        return messages;
    }

    public MenuModel? GetItemInfo(MessageModel message)
    {
        return string.IsNullOrWhiteSpace(message.Content) ? null : JsonSerializer.Deserialize<MenuModel>(message.Content);
    }

    public async Task MarkItemAsProcessed(UniqueId uid)
    {
        await _imapClient.Inbox.AddFlagsAsync(new[] { uid }, MessageFlags.Deleted, true);
    }

    private static bool MessageValidation(IMessageSummary message)
    {
        return message.Envelope.Subject == "FormReply" &&
               message.Envelope.From.Mailboxes.All(x => x.Domain == "forms-mailer.yaconnect.com");
    }
}