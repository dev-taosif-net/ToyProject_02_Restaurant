using FluentValidation;
using MediatR;

namespace Restaurant.Application.Restaurants.Commands.Update;

public class UpdateRestaurantCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool HasDelivery { get; set; }
}


public class UpdateRestaurantDtoValidator : AbstractValidator<UpdateRestaurantCommand>
{
    public UpdateRestaurantDtoValidator()
    {
        RuleFor(x=>x.Name)
            .NotNull()
            .Length(5,100)
            .NotEmpty();
    }
}