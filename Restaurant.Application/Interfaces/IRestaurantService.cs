namespace Restaurant.Application.Interfaces;

public interface IRestaurantService
{
    Task<IEnumerable<Domain.Entities.Restaurant>>  GetAllRestaurantsAsync();
    Task<Domain.Entities.Restaurant?> GetRestaurantByIdAsync(int id);
}