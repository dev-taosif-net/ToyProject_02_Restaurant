using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Services.Restaurant;
using Restaurant.Application.Services.Restaurant.Dtos;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler(IRestaurantRepository repository , ILogger<GetRestaurantByIdQueryHandler> logger) 
    : IRequestHandler<GetRestaurantByIdQuery , RestaurantDto?>
{
    public async Task<RestaurantDto?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Get restaurant by id: {Id}", request.Id );
        var restaurant = await repository.GetByIdAsync(request.Id) ;
        return RestaurantDto.FromEntity(restaurant);
    }
}