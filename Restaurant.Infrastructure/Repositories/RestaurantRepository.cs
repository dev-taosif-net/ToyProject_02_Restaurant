using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Persistence.Context;

namespace Restaurant.Infrastructure.Repositories;

internal class RestaurantRepository(RestaurantDbContext context) : IRestaurantRepository
{
    public async Task<IEnumerable<Domain.Entities.Restaurant>> GetAllAsync()
    {
        var result = await context.Restaurants
            .Include(x=>x.Dishes)
            .ToListAsync();
        
        return result;
    }

    public async Task<Domain.Entities.Restaurant?> GetByIdAsync(int id)
    {
       return await context.Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<int> AddAsync(Domain.Entities.Restaurant restaurant)
    {
        await context.Restaurants.AddAsync(restaurant);
        await context.SaveChangesAsync();
        return restaurant.Id;
    }

    public async Task<bool> UpdateAsync(Domain.Entities.Restaurant restaurant)
    {
        context.Restaurants.Update(restaurant);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task DeleteAsync(Domain.Entities.Restaurant restaurant)
    {
        context.Restaurants.Remove(restaurant);
        await context.SaveChangesAsync();
    }
}