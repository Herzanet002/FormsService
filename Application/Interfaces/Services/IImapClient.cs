using Application.Common.Configurations;
using MailKit;
using MailService.Configurations;
using MailService.Models;

namespace Application.Interfaces.Services;

public interface IImapClient
{
    void InitializeClient(ClientSettings clientSettings, FormsConfiguration formsConfiguration);

    Task<List<MessageModel>> ReceiveItemsAsync();

    Task MarkItemAsProcessed(UniqueId uid);
}