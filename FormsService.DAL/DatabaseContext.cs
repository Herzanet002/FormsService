using MailService.Models;
using MailService.Models.MenuModels;
using Microsoft.EntityFrameworkCore;

namespace FormsService.DAL
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
            Menu.Add(new MenuModel
            {
                FirstCourse = new Dish(),
                Location = "На работе",
                Name = "efse",
                Salad = new Dish(),
                Soup = new Dish()
            });
            SaveChanges();
        }

        public DbSet<MenuModel> Menu { get; set; }
    }
}