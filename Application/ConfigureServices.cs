using Application.Features.Dish.Commands.CreateDish;
using Application.Features.Dish.Commands.DeleteDish;
using Application.Features.Dish.Commands.UpdateDish;
using Application.Features.Dish.Queries.GetDishes;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
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
}