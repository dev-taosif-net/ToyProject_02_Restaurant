using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Services;

namespace Restaurant.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services )
    {
        services.AddScoped<IRestaurantService, RestaurantService>();
    }
}