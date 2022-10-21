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
            ConfigureEntities(modelBuilder);

            if (IsDataSeeding)
            {
                Seed(modelBuilder);
            }
        }

        private static void ConfigureEntities(ModelBuilder modelBuilder)
        {
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
            modelBuilder.Entity<DishOrder>().Ignore(attr => attr.Id);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(RealDataSeed.GetAllPersons());
            modelBuilder.Entity<Dish>().HasData(RealDataSeed.GetAllDishes());
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DishOrder> DishOrders { get; set; }
    }
}