using FormsService.DAL.Entities;
using FormsService.DAL.Entities.Seeding;
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

            modelBuilder.Entity<Person>().HasData(TestDataSeed.GetTestPersons(10));
            modelBuilder.Entity<Dish>().HasData(TestDataSeed.GetTestDishes(10));
            modelBuilder.Entity<Order>().HasData(TestDataSeed.GetTestOrders(10));
            modelBuilder.Entity<DishOrder>().HasData(TestDataSeed.GetTestDishOrder(10));
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DishOrder> DishOrders { get; set; }
    }
}