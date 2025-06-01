using Microsoft.Extensions.Logging;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Services;

public class RestaurantService(IRestaurantRepository repository , ILogger<RestaurantService> logger) : IRestaurantService
{
    public Task<IEnumerable<Domain.Entities.Restaurant>> GetAllRestaurantsAsync()
    { 
        logger.LogInformation("Get all restaurants");
        return repository.GetAllAsync();
    }

    public Task<Domain.Entities.Restaurant?> GetRestaurantByIdAsync(int id)
    {
        logger.LogInformation("Get restaurant by id: {Id}", id);
        return repository.GetByIdAsync(id);
    }
}