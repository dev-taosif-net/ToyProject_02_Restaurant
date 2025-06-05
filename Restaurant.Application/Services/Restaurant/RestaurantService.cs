using Microsoft.Extensions.Logging;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Services.Restaurant.Dtos;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Services.Restaurant;

public class RestaurantService(IRestaurantRepository repository , ILogger<RestaurantService> logger) : IRestaurantService
{
    public async Task<IEnumerable<RestaurantDto?>> GetAllRestaurantsAsync()
    { 
        logger.LogInformation("Get all restaurants");
        var restaurants = await repository.GetAllAsync();
        return restaurants.Select(RestaurantDto.FromEntity);
    }

    public async Task<RestaurantDto?> GetRestaurantByIdAsync(int id)
    {
        logger.LogInformation("Get restaurant by id: {Id}", id);
        var restaurant = await repository.GetByIdAsync(id) ;
        return RestaurantDto.FromEntity(restaurant);
    }

    public async Task<int> CreateRestaurantAsync(CreateRestaurantDto obj)
    {
        logger.LogInformation("Create new restaurant");
        var restaurant = CreateRestaurantDto.ToEntity(obj);

        var id= await repository.AddAsync(restaurant);
        return id;
    }
}