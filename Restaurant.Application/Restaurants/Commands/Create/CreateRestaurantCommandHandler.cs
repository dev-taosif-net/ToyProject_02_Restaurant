using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Services.Restaurant;
using Restaurant.Application.Services.Restaurant.Dtos;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Commands.Create;

public class CreateRestaurantCommandHandler(IRestaurantRepository repository , ILogger<CreateRestaurantCommandHandler> logger) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Create new restaurant");
        var restaurant = CreateRestaurantCommand.ToEntity(request);

        var id= await repository.AddAsync(restaurant);
        return id;
    }
}