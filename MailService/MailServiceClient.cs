using MailService.Configurations;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailService.Models;
using MimeKit;
using System.Text;
using System.IO;
using System;

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
                    //var body = Encoding.UTF8.GetBytes(await inboxFolder.GetBodyPartAsync(message.UniqueId, message.HtmlBody));
                    messages.Add(new MessageModel
                    {
                        //Content = message.HtmlBody != null ? body.ToString() : "",
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

        private async Task<MemoryStream> ReadMessage(IMailFolder myfolder)
        {
            MemoryStream mstream = new MemoryStream();
            MemoryStream endstream = new MemoryStream();
            foreach (var summary in await myfolder.FetchAsync(await myfolder.SearchAsync(SearchQuery.All, CancellationToken.None),
                         MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure | MessageSummaryItems.Envelope))
            {


                if (summary.HtmlBody != null)
                {

                    var body = (MimePart)myfolder.GetBodyPart(summary.UniqueId, summary.HtmlBody);
                    string charset = body.ContentType.Charset;
                    body.Content.DecodeTo(mstream);
                    byte[] mstreamBytes = mstream.ToArray();
                    if (!charset.Contains("utf-8"))
                    {
                        Encoding utf8 = Encoding.GetEncoding("utf-8");
                        Encoding anotherEnc = Encoding.GetEncoding(charset);
                        byte[] utf8Bytes = Encoding.Convert(anotherEnc, utf8, mstreamBytes);
                        endstream.Write(utf8Bytes, 0, utf8Bytes.Length);
                    }
                    else
                    {
                        endstream.Write(mstreamBytes, 0, mstreamBytes.Length);
                    }

                }
                else
                {
                    var body = (MimePart)myfolder.GetBodyPart(summary.UniqueId, summary.TextBody);
                    string charset = body.ContentType.Charset;
                    body.Content.DecodeTo(mstream);
                    byte[] mstreamBytes = mstream.ToArray();
                    if (!charset.Contains("utf-8"))
                    {
                        Encoding utf8 = Encoding.GetEncoding("utf-8");
                        Encoding anotherEnc = Encoding.GetEncoding(charset);
                        byte[] utf8Bytes = Encoding.Convert(anotherEnc, utf8, mstreamBytes);
                        endstream.Write(utf8Bytes, 0, utf8Bytes.Length);
                    }
                    else
                    {
                        endstream.Write(mstreamBytes, 0, mstreamBytes.Length);
                    }


                }
                endstream.Seek(0, SeekOrigin.Begin);
            }

            return endstream;
        }
    }
}