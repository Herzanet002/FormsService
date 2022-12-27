using Application.Features.Dishes.Commands.CreateDish;
using Application.Features.Dishes.Commands.DeleteDish;
using Application.Features.Dishes.Commands.UpdateDish;
using Application.Features.Dishes.Queries.GetDishes;
using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Commands.DeleteOrder;
using Application.Features.Orders.Commands.UpdateOrder;
using Application.Features.Orders.Queries.GetOrders;
using Application.Features.Persons.Commands.CreatePerson;
using Application.Features.Persons.Commands.DeletePerson;
using Application.Features.Persons.Commands.UpdatePerson;
using Application.Features.Persons.Queries.GetAllPersons;
using Application.Features.Persons.Queries.GetPersonById;
using Application.Mapping;
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


            .AddTransient<ICreateOrderHandler, CreateOrderHandler>()
            .AddTransient<IDeleteOrderHandler, DeleteOrderHandler>()
            .AddTransient<IDeleteOrderByIdHandler, DeleteOrderByIdHandler>()
            .AddTransient<IUpdateOrderHandler, UpdateOrderHandler>()
            .AddTransient<IGetAllOrdersHandler, GetAllOrdersHandler>()
            .AddTransient<IGetOrderByIdHandler, GetOrderByIdHandler>()

            .AddTransient<ICreatePersonHandler, CreatePersonHandler>()
            .AddTransient<IDeletePersonHandler, DeletePersonHandler>()
            .AddTransient<IDeletePersonByIdHandler, DeletePersonByIdHandler>()
            .AddTransient<IUpdatePersonHandler, UpdatePersonHandler>()
            .AddTransient<IGetAllPersonsHandler, GetAllPersonsHandler>()
            .AddTransient<IGetPersonByIdHandler, GetPersonByIdHandler>()
            ;

        services.RegisterMapsterConfiguration();

        return services;
    }
}