namespace Restaurant.Application.Services.Dish.Dtos;

public class CreateDishDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int KiloCalories { get; set; } = 0;

    public static Domain.Entities.Dish? ToEntity(CreateDishDto? dto)
    {
        if (dto == null) return null;
        
        return new Domain.Entities.Dish()
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            KiloCalories = dto.KiloCalories,
        };
    }
    
}