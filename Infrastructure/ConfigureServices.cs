using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
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
            services.AddScoped<IRepository<Dish>, DbRepository<Dish>>();
            services.AddScoped<IRepository<Order>, DbRepository<Order>>();
            services.AddScoped<IRepository<DishOrder>, DbRepository<DishOrder>>();
            services.AddScoped<IRepository<Person>, DbRepository<Person>>();
            services.AddScoped<IRepository<DishCategory>, DbRepository<DishCategory>>();
            return services;
        }
    }
}
