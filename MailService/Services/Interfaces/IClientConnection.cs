namespace MailService.Services.Interfaces
{
    public interface IClientConnection
    {
        Task ConnectAsync();

        Task AuthenticateAsync();
    }
}
