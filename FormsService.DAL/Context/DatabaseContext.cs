using FormsService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormsService.DAL.Context
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Dish>()
                .HasMany(o => o.Orders)
                .WithMany(d => d.Dishes)
                .UsingEntity<DishOrder>(
                    j => j
                        .HasOne(pt => pt.Order)
                        .WithMany(t => t.DishOrders)
                        .HasForeignKey(pt => pt.OrderID),

                    j => j
                        .HasOne(pt => pt.Dish)
                        .WithMany(p => p.DishOrders)
                        .HasForeignKey(pt => pt.DishID),

                    j =>
                    {
                        j.Property(pt => pt.Count).HasDefaultValue(0);
                        j.HasKey(t => new { t.OrderID, t.DishID });
                        j.ToTable(nameof(DishOrder));
                    });

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}