using Restaurant.Application.Services.Restaurant.Dtos;

namespace Restaurant.Application.Interfaces;

public interface IRestaurantService
{
    Task<IEnumerable<RestaurantDto?>> GetAllRestaurantsAsync();
    Task<RestaurantDto?> GetRestaurantByIdAsync(int id);
    Task<int> CreateRestaurantAsync(CreateRestaurantDto restaurant);
}