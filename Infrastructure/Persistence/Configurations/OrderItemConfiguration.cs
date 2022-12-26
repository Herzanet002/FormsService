using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
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
        }
    }
}
