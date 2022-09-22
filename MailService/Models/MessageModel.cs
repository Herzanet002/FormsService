namespace MailService.Models
{
    public class MessageModel
    {
        public string From { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string? Content { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
