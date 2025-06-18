using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Commands.Update;

public class UpdateRestaurantCommandHandler(IRestaurantRepository repository , ILogger<UpdateRestaurantCommand> logger)
    : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Create new restaurant");
        var restaurant = await repository.GetByIdAsync(request.Id);
        
        if (restaurant is null) return false;
        restaurant.Name = request.Name;
        restaurant.Description = request.Description;
        restaurant.HasDelivery = request.HasDelivery;
        
        await repository.UpdateAsync(restaurant);
        
        return true;
    }
}