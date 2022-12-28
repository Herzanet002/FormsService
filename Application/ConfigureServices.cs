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
            .AddScoped<ICreateDishHandler, CreateDishHandler>()
            .AddScoped<IDeleteDishHandler, DeleteDishHandler>()
            .AddScoped<IGetAllDishesHandler, GetAllDishesHandler>()
            .AddScoped<IGetDishesByCategoriesHandler, GetDishesByCategoriesHandler>()
            .AddScoped<IUpdateDishHandler, UpdateDishHandler>()
            .AddScoped<ICreateOrderHandler, CreateOrderHandler>()
            .AddScoped<IDeleteOrderHandler, DeleteOrderHandler>()
            .AddScoped<IDeleteOrderByIdHandler, DeleteOrderByIdHandler>()
            .AddScoped<IUpdateOrderHandler, UpdateOrderHandler>()
            .AddScoped<IGetAllOrdersHandler, GetAllOrdersHandler>()
            .AddScoped<IGetOrderByIdHandler, GetOrderByIdHandler>()
            .AddScoped<ICreatePersonHandler, CreatePersonHandler>()
            .AddScoped<IDeletePersonHandler, DeletePersonHandler>()
            .AddScoped<IDeletePersonByIdHandler, DeletePersonByIdHandler>()
            .AddScoped<IUpdatePersonHandler, UpdatePersonHandler>()
            .AddScoped<IGetAllPersonsHandler, GetAllPersonsHandler>()
            .AddScoped<IGetPersonByIdHandler, GetPersonByIdHandler>()
            ;

        services.RegisterMapsterConfiguration();

        return services;
    }
}