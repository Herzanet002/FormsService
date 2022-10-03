namespace MailService.Models.MenuModels
{
    public class Dish : BaseEntity
    {
        public string? Name { get; set; }
        public int Price { get; set; }
    }
}