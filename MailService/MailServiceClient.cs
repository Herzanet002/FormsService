using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailService.Configurations;
using MailService.Models;
using MimeKit;
using JsonSerializer = System.Text.Json.JsonSerializer;
using MailService.Helpers;

namespace MailService
{
    public class MailServiceClient
    {
        private readonly ClientSettings _clientSettings;

        public MailServiceClient(ClientSettings clientSettings)
        {
            _clientSettings = clientSettings;
        }

        public async Task<List<MessageModel>> ReceiveEmail()
        {
            using var client = new ImapClient();
            await client.ConnectAsync(_clientSettings.Host, _clientSettings.Port, _clientSettings.Ssl);
            await client.AuthenticateAsync(_clientSettings.Login, _clientSettings.Password);

            var inboxFolder = client.Inbox;
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
                messages.Add(new MessageModel
                {
                    Content = message.HtmlBody.ToString(),
                    From = message.Envelope.From.ToString(),
                    Subject = message.Envelope.Subject,
                    Date = message.Envelope.Date!.Value
                });
                //await inboxFolder.AddFlagsAsync(new[] { message.UniqueId }, MessageFlags.Deleted, true);
            }
            //await inboxFolder.ExpungeAsync();
            return messages;
        }



    }
}