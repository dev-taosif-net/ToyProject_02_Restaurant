using MediatR;
using Restaurant.Application.Services.Restaurant.Dtos;

namespace Restaurant.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQuery : IRequest<RestaurantDto?>
{
    public int Id { get; set; }
}