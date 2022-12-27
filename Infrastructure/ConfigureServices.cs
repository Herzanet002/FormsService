using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(
            options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DbSource"))
                    .UseSnakeCaseNamingConvention()
                    .EnableSensitiveDataLogging();
            });
        services.AddScoped<IDishRepository, DishRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IDishOrderRepository, DishOrderRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IDishCategoryRepository, DishCategoryRepository>();
        return services;
    }
}