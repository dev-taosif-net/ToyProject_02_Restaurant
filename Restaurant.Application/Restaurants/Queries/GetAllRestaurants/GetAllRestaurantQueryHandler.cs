using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Services.Restaurant;
using Restaurant.Application.Services.Restaurant.Dtos;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantQueryHandler(IRestaurantRepository repository , ILogger<GetAllRestaurantQueryHandler> logger) 
    : IRequestHandler<GetAllRestaurantQuery, List<RestaurantDto>>
{
    public async Task<List<RestaurantDto?>> Handle(GetAllRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Get all restaurants");
        var restaurants = await repository.GetAllAsync();
        return restaurants.Select(RestaurantDto.FromEntity).ToList();
    }
}