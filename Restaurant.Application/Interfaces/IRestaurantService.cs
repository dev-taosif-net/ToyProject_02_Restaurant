namespace Restaurant.Application.Interfaces;

public interface IRestaurantService
{
    Task<IEnumerable<Domain.Entities.Restaurant>>  GetAllRestaurantsAsync();
}