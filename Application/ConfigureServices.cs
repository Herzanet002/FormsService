using Application.Features.Dishes.Commands.CreateDish;
using Application.Features.Dishes.Commands.DeleteDish;
using Application.Features.Dishes.Commands.UpdateDish;
using Application.Features.Dishes.Queries.GetDishes;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
    {
        services
            .AddTransient<ICreateDishHandler, CreateDishHandler>()
            .AddTransient<IDeleteDishHandler, DeleteDishHandler>()
            .AddTransient<IGetAllDishesHandler, GetAllDishesHandler>()
            .AddTransient<IGetDishesByCategoriesHandler, GetDishesByCategoriesHandler>()
            .AddTransient<IUpdateDishHandler, UpdateDishHandler>()
            ;

        return services;
    }
}