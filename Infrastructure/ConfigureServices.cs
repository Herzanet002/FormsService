using Application.Common.Configurations;
using Application.Common;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Infrastructure.Services;
using MailService.Configurations;
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

    public static IServiceCollection ConfigureIMapService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<ClientSettings>(
            configuration.GetSection(nameof(IMapClientConfigurations)));
        return services;
    }

    public static IServiceCollection ConfigureFormsService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<FormsConfiguration>(
            configuration.GetSection(nameof(FormsConfiguration)));
        return services;
    }

    public static IServiceCollection AddMailHostedService(this IServiceCollection services)
    {
        services.AddHostedService<MailHostedService>();
        return services;
    }

    public static IServiceCollection AddIMapClientService(this IServiceCollection services)
    {
        services.AddTransient<IImapClient, MenuSourceClient>();
        return services;
    }
}