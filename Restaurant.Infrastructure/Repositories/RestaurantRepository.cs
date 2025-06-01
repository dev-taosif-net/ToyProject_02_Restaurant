using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Persistence.Context;

namespace Restaurant.Infrastructure.Repositories;

internal class RestaurantRepository(RestaurantDbContext context) : IRestaurantRepository
{
    public async Task<IEnumerable<Domain.Entities.Restaurant>> GetAllAsync()
    {
        var result = await context.Restaurants.ToListAsync();
        return result;
    }

    public async Task<Domain.Entities.Restaurant?> GetByIdAsync(int id)
    {
       return await context.Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
}