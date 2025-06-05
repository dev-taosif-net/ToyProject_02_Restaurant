using MediatR;
using Restaurant.Application.Services.Restaurant.Dtos;

namespace Restaurant.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantQuery : IRequest<List<RestaurantDto>?>;