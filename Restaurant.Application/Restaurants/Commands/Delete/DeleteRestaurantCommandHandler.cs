using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurants.Commands.Create;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Commands.Delete;

public class DeleteRestaurantCommandHandler(IRestaurantRepository repository , ILogger<CreateRestaurantCommandHandler> logger) 
    : IRequestHandler< DeleteRestaurantCommand , bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Delete restaurant by Id {request.Id}");
        var data = await repository.GetByIdAsync(request.Id);
        if (data == null) return false;
        
        await repository.DeleteAsync(data);
        return true;
        
    }
}