namespace MailService.Configurations;

public class ClientSettings
{
    public string? Host { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public int Port { get; set; }
    public bool Ssl { get; set; }
    public bool IsActive { get; set; }
    public int EmailReadInterval { get; set; }
}