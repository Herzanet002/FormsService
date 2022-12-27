using Application.Features.Dishes;
using Domain.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Mapping
{
    public static class MapsterConfiguration
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Order, OrderDto>
                .NewConfig()
                .Map(dest => dest.PersonId, src => src.Person.Id);

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
