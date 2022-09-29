using MailKit;

namespace MailService.Models
{
    public class MessageModel
    {
        public UniqueId UniqueId { get; set; }
        public string From { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string? Content { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}