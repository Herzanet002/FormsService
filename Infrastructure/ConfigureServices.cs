using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
	public static IServiceCollection AddPostresqlDatabase(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<DatabaseContext>(
			options =>
			{
				options.UseNpgsql(configuration.GetConnectionString("DbSource"))
					.UseSnakeCaseNamingConvention()
					.EnableSensitiveDataLogging();
			});
        return services;
	}

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDishRepository, DishRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IDishOrderRepository, DishOrderRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IDishCategoryRepository, DishCategoryRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        return services;
    }

	public static IServiceCollection AddReportsServices(this IServiceCollection services)
	{
		services.AddScoped<IWordWorkerService<Order>, WordWorkerServiceService<Order>>();
		services.AddScoped<ExcelWorkerService<Person>>();

		return services;
	}
}