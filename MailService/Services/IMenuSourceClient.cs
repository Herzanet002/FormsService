using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailService.Configurations;
using MailService.Models;
using Microsoft.Extensions.Logging;
using MimeKit;
using IImapClient = MailService.Services.Interfaces.IImapClient;

namespace MailService.Services
{
    public class IMenuSourceClient : IImapClient
    {
        private readonly ImapClient _imapClient;

        private readonly ILogger<IMenuSourceClient> _logger;

        private ClientSettings? _clientSettings;

        public IMenuSourceClient(ILogger<IMenuSourceClient> logger)
        {
            _logger = logger;
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
            if (_clientSettings == null) throw new NullReferenceException(nameof(_clientSettings));
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
            if (_clientSettings == null) throw new NullReferenceException(nameof(_clientSettings));

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
                    Content = message.HtmlBody.ToString(),
                    From = message.Envelope.From.ToString(),
                    Subject = message.Envelope.Subject,
                    Date = message.Envelope.Date!.Value
                };

                _logger.LogInformation($"Message in inbox folder: UniqID: {messageModel.UniqueId}, sent: {messageModel.Date}");
                messages.Add(messageModel);
                //MarkItemAsProcessed();
            }

            return messages;
        }

        public async Task MarkItemAsProcessed(UniqueId uid)
        {
            await _imapClient.Inbox.AddFlagsAsync(new[] { uid }, MessageFlags.Deleted, true);
            await _imapClient.Inbox.ExpungeAsync();
        }

        private bool MessageValidation(IMessageSummary message)
        {
            return message.Envelope.Subject == "FormReply" &&
                   message.Envelope.From.Mailboxes.All(x => x.Domain == "forms-mailer.yaconnect.com");
        }



    }
}
