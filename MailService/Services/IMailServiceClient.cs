using MailService.Configurations;
using MailService.Models;

namespace MailService.Services;

public interface IMailServiceClient
{
    void InitializeClient(ClientSettings clientSettings);

    Task<List<MessageModel>> ReceiveEmail();

    Task ConnectAsync();

    Task AuthenticateAsync();
}