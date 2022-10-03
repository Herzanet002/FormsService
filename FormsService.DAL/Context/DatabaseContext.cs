using MailService.Models;
using Microsoft.EntityFrameworkCore;

namespace FormsService.DAL.Context
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<MenuModel> Menu { get; set; }
    }
}