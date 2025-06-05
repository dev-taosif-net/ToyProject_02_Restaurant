using FluentValidation;
using MediatR;

namespace Restaurant.Application.Restaurants.Commands.Create;

public class CreateRestaurantCommand : IRequest<int>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public bool HasDelivery { get; set; }

    public string? ContactEmail { get; set; }
    public string? ContactNumber { get; set; }
    
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    
    public static Domain.Entities.Restaurant ToEntity(CreateRestaurantCommand dto)
    {
        return new Domain.Entities.Restaurant()
        {
            Name = dto.Name,
            Description = dto.Description,
            Category = dto.Category,
            ContactEmail = dto.ContactEmail,
            ContactNumber = dto.ContactNumber,
            HasDelivery = dto.HasDelivery,
            Address = new Domain.Entities.Address()
            {
                Street = dto.Street,
                City = dto.City,
                PostalCode = dto.PostalCode,
            },
            
        };
    }
}

public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantCommand>
{
    public CreateRestaurantDtoValidator()
    {
        RuleFor(x=>x.Name)
            .NotNull()
            .Length(5,100)
            .NotEmpty();
    }
}