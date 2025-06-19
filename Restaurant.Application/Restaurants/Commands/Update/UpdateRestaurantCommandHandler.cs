using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Commands.Update;

public class UpdateRestaurantCommandHandler(IRestaurantRepository repository , ILogger<UpdateRestaurantCommand> logger)
    : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Create new restaurant");
        var restaurant = await repository.GetByIdAsync(request.Id);
        
        if (restaurant is null) throw new NotFoundException("Restaurant", request.Id.ToString());
        restaurant.Name = request.Name;
        restaurant.Description = request.Description;
        restaurant.HasDelivery = request.HasDelivery;
        
        await repository.UpdateAsync(restaurant);
        
    }
}