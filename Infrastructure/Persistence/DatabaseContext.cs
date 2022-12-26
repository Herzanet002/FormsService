using Domain.Entities;
using Infrastructure.Persistence.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public sealed class DatabaseContext : DbContext
    {
        private static readonly bool IsDataSeeding = true;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (IsDataSeeding)
            {
                Seed(modelBuilder);
            }
            base.OnModelCreating(modelBuilder);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(RealDataSeed.GetAllPersons());
            modelBuilder.Entity<Dish>().HasData(RealDataSeed.GetAllDishes());
            modelBuilder.Entity<DishCategory>().HasData(RealDataSeed.GetAllDishCategories());
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DishOrder> DishOrders { get; set; }
        public DbSet<DishCategory> Categories { get; set; }
    }
}