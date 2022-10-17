using FormsService.DAL.Entities;
using FormsService.DAL.Entities.Seeding;
using Microsoft.EntityFrameworkCore;

namespace FormsService.DAL.Context
{
    public sealed class DatabaseContext : DbContext
    {
        private static readonly bool IsDataSeeding = true;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<DishOrder>().HasKey(dishOrder => new { dishOrder.OrderID, dishOrder.DishID });
            modelBuilder
                .Entity<Order>()
                .HasMany(o => o.Dishes)
                .WithMany(d => d.Orders)
                .UsingEntity<DishOrder>(
                    j => j
                        .HasOne(pt => pt.Dish)
                        .WithMany(p => p.DishOrders)
                        .HasForeignKey(pt => pt.DishID),
                    j => j
                        .HasOne(pt => pt.Order)
                        .WithMany(t => t.DishOrders)
                        .HasForeignKey(pt => pt.OrderID),
                    j =>
                    {
                        j.Property(pt => pt.Count).HasDefaultValue(1);
                        j.HasKey(t => new { t.OrderID, t.DishID });
                        j.ToTable("dish_orders");
                    });

            if (IsDataSeeding)
            {
                Seed(modelBuilder);
            }
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>().HasData(TestDataSeed.GetTestPersons(10));
            //modelBuilder.Entity<Dish>().HasData(TestDataSeed.GetTestDishes(10));
            //modelBuilder.Entity<Order>().HasData(TestDataSeed.GetTestOrders(10));
            //modelBuilder.Entity<DishOrder>().HasData(TestDataSeed.GetTestDishOrder(10));

            modelBuilder.Entity<Person>().HasData(RealDataSeed.GetAllPersons());
            modelBuilder.Entity<Dish>().HasData(RealDataSeed.GetAllDishes());
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DishOrder> DishOrders { get; set; }
    }
}