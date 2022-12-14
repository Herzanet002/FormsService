using System.Reflection;
using Domain.Entities;
using Infrastructure.Persistence.Seeding;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public sealed class DatabaseContext : DbContext
{
    private static readonly bool IsDataSeeding = true;

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<DishOrder> DishOrders { get; set; }
    public DbSet<DishCategory> Categories { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        if (IsDataSeeding) Seed(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasData(RealDataSeed.GetAllPersons());
        modelBuilder.Entity<Dish>().HasData(RealDataSeed.GetAllDishes());
        modelBuilder.Entity<DishCategory>().HasData(RealDataSeed.GetAllDishCategories());
        modelBuilder.Entity<Location>().HasData(RealDataSeed.GetAllLocations());
    }
}