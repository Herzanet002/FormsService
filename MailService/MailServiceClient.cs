using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailService.Configurations;
using MailService.Models;
using MimeKit;
using System.Text.RegularExpressions;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
                await inboxFolder.SearchAsync(SearchQuery.All, CancellationToken.None), MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure | MessageSummaryItems.Envelope);

            foreach (var message in inboxMessages)
            {
                if (message.Envelope.Subject == "FormReply" &&
                    (message.Envelope.From.Mailboxes.Count(x => x.Domain == "forms-mailer.yaconnect.com") != 0))
                {
                    var body = await inboxFolder.GetBodyPartAsync(message.UniqueId, message.HtmlBody) as TextPart;
                    var jsonPart = ParseHtml(body.Text);
                    var deserialized = JsonSerializer.Deserialize<MenuModel>(jsonPart);
                    messages.Add(new MessageModel
                    {
                        Content = message.HtmlBody.ToString(),
                        From = message.Envelope.From.ToString(),
                        Subject = message.Envelope.Subject,
                        Date = message.Envelope.Date!.Value
                    });
                }
                //await inboxFolder.AddFlagsAsync(new[] { message.UniqueId }, MessageFlags.Deleted, true);
            }
            //await inboxFolder.ExpungeAsync();
            return messages;
        }

        private string ParseHtml(string htmlText)
        {
            Regex regex = new Regex("{(.*?)}", RegexOptions.Compiled);
            var jsonString = regex.Match(htmlText).Value;

            var unescaped = Regex.Unescape(jsonString);
            var withoutQuot = Regex.Replace(unescaped, "&quot;", @"""").Trim();
            return withoutQuot;
        }

    }
}