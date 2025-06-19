using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurants.Commands.Create;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Commands.Delete;

public class DeleteRestaurantCommandHandler(IRestaurantRepository repository , ILogger<CreateRestaurantCommandHandler> logger) 
    : IRequestHandler< DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Delete restaurant by Id {request.Id}");
        var data = await repository.GetByIdAsync(request.Id);
        if (data == null) throw new NotFoundException("Restaurant", request.Id.ToString());

        await repository.DeleteAsync(data);

    }

}