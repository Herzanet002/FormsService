using MailKit;
using MailService.Configurations;
using MailService.Models;

namespace MailService.Services.Interfaces
{
    public interface IImapClient : IClientConnection
    {
        void InitializeClient(ClientSettings clientSettings);

        Task<List<MessageModel>> ReceiveEmail();

        Task MoveToTrash(UniqueId uid);
    }
}
