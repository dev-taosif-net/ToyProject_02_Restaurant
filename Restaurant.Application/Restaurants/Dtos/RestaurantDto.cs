namespace Restaurant.Application.Services.Restaurant.Dtos;

public class RestaurantDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public bool HasDelivery { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    
    public static RestaurantDto? FromEntity(Domain.Entities.Restaurant? restaurant)
    {
        if (restaurant is null)
        {
            return null;
        }
        
        return new RestaurantDto
        {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Description = restaurant.Description,
            Category = restaurant.Category,
            HasDelivery = restaurant.HasDelivery,
            City = restaurant?.Address?.City,
            Street = restaurant?.Address?.Street,
            PostalCode = restaurant?.Address?.PostalCode,
        };
        
    }
    
}