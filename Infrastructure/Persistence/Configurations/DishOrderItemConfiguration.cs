using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class DishOrderItemConfiguration : IEntityTypeConfiguration<DishOrder>
{
    public void Configure(EntityTypeBuilder<DishOrder> builder)
    {
        builder.Ignore(attr => attr.Id);
    }
}