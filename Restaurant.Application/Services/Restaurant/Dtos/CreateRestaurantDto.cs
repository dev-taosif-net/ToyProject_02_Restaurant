using FluentValidation;
using Restaurant.Application.Services.Dish.Dtos;

namespace Restaurant.Application.Services.Restaurant.Dtos;

public class CreateRestaurantDto
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
    
    public List<CreateDishDto?> Dishes { get; set; } = [];

    public static Domain.Entities.Restaurant ToEntity(CreateRestaurantDto dto)
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
            Dishes = dto.Dishes.Select(CreateDishDto.ToEntity).ToList()

        };
    }
    
}

public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    public CreateRestaurantDtoValidator()
    {
        RuleFor(x=>x.Name)
            .NotNull()
            .Length(5,100)
            .NotEmpty();
    }
}