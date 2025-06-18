namespace Restaurant.Domain.Repositories;

public interface IRestaurantRepository
{
    Task<IEnumerable<Entities.Restaurant>>  GetAllAsync();
    Task<Entities.Restaurant?> GetByIdAsync(int id);
    Task<int> AddAsync(Entities.Restaurant restaurant);
    Task<bool> UpdateAsync(Entities.Restaurant restaurant);
    Task DeleteAsync(Entities.Restaurant restaurant);
}