using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailService.Configurations;
using MailService.Helpers;
using MailService.Models;
using Microsoft.Extensions.Logging;
using MimeKit;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MailService
{

    public interface IMailServiceClient
    {
        void Init(ClientSettings clientSettings);
        Task<List<MessageModel>> ReceiveEmail();
    }
    public class MailServiceClient : IMailServiceClient
    {
        private readonly ILogger<MailServiceClient> _logger;
        private readonly ImapClient _imapClient;
        private ClientSettings? _clientSettings;
        public MailServiceClient(ILogger<MailServiceClient> logger)
        {
            _logger = logger;
            _imapClient = new ImapClient();
        }
        public async Task<List<MessageModel>> ReceiveEmail()
        {
            if (_clientSettings == null) throw (new ArgumentNullException(nameof(_clientSettings)));

            await _imapClient.ConnectAsync(_clientSettings.Host, _clientSettings.Port, _clientSettings.Ssl);
            await _imapClient.AuthenticateAsync(_clientSettings.Login, _clientSettings.Password);

            var inboxFolder = _imapClient.Inbox;
            await inboxFolder.OpenAsync(access: FolderAccess.ReadWrite);
            var messages = new List<MessageModel>();
            var inboxMessages = await inboxFolder.FetchAsync(
                await inboxFolder.SearchAsync(SearchQuery.All, CancellationToken.None),
                MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure | MessageSummaryItems.Envelope);

            foreach (var message in inboxMessages)
            {
                if (message.Envelope.Subject != "FormReply" ||
                    message.Envelope.From.Mailboxes.All(x => x.Domain != "forms-mailer.yaconnect.com")) continue;

                if (await inboxFolder.GetBodyPartAsync(message.UniqueId, message.HtmlBody) is not TextPart body) continue;

                var jsonPart = body.Text.GetJsonFromHtml();
                var deserialized = JsonSerializer.Deserialize<MenuModel>(jsonPart);

                var messageModel = new MessageModel
                {
                    UniqueId = message.UniqueId,
                    Content = message.HtmlBody.ToString(),
                    From = message.Envelope.From.ToString(),
                    Subject = message.Envelope.Subject,
                    Date = message.Envelope.Date!.Value
                };
                _logger.LogInformation($"Message in inbox folder: UniqID: {messageModel.UniqueId}, date: {messageModel.Date}");
                messages.Add(messageModel);
                //await inboxFolder.AddFlagsAsync(new[] { message.UniqueId }, MessageFlags.Deleted, true);
            }
            //await inboxFolder.ExpungeAsync();
            return messages;
        }


        public void Init(ClientSettings clientSettings)
        {
            _clientSettings = clientSettings;
        }
    }
}