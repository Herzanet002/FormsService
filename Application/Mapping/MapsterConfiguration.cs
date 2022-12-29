using System.Reflection;
using Application.Features.Dishes;
using Application.Features.Dishes.Queries;
using Application.Features.Orders;
using Domain.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Mapping;

public static class MapsterConfiguration
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig<Order, OrderDto>
            .NewConfig()
            .Map(dest => dest.PersonId, src => src.Person.Id);

        TypeAdapterConfig<Dish, GetDishCommand>
            .NewConfig()
            .Map(dest => dest.DishCategoryName, src => src.Category!.Name);

        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    }
}