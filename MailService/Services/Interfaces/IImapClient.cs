using MailKit;
using MailService.Configurations;
using MailService.Models;

namespace MailService.Services.Interfaces;

public interface IImapClient
{
    void InitializeClient(ClientSettings clientSettings, FormsConfiguration formsConfiguration);

    Task<List<MessageModel>> ReceiveItem();

    Task MarkItemAsProcessed(UniqueId uid);
}