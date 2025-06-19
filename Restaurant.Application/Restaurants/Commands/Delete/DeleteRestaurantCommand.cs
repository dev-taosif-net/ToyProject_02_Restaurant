using MediatR;

namespace Restaurant.Application.Restaurants.Commands.Delete;

public class DeleteRestaurantCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}