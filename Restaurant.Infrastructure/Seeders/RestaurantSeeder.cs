﻿using Restaurant.Domain.Entities;
using Restaurant.Infrastructure.Persistence.Context;

namespace Restaurant.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantDbContext restaurantDbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await restaurantDbContext.Database.CanConnectAsync())
        {
            if (!restaurantDbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                await restaurantDbContext.Restaurants.AddRangeAsync(restaurants);
                await restaurantDbContext.SaveChangesAsync();
            }

        }
    }
    
    IEnumerable<Domain.Entities.Restaurant> GetRestaurants()
    {
        
        List<Domain.Entities.Restaurant> restaurants = [
            new()
            {
                Name = "KFC",
                Category = "Fast Food",
                Description =
                    "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
                ContactEmail = "contact@kfc.com",
                HasDelivery = true,
                Dishes =
                [
                    new Dish
                    {
                        Name = "Nashville Hot Chicken",
                        Description = "Nashville Hot Chicken (10 pcs.)",
                        Price = 10.30M,
                    },

                    new Dish
                    {
                        Name = "Chicken Nuggets",
                        Description = "Chicken Nuggets (5 pcs.)",
                        Price = 5.30M,
                    },
                ],
                Address = new Address
                {
                    City = "London",
                    Street = "Cork St 5",
                    PostalCode = "WC2N 5DU"
                },
                
            },
            new ()
            {
                Name = "McDonald",
                Category = "Fast Food",
                Description =
                    "McDonald's Corporation (McDonald's), incorporated on December 21, 1964, operates and franchises McDonald's restaurants.",
                ContactEmail = "contact@mcdonald.com",
                HasDelivery = true,
                Address = new Address()
                {
                    City = "London",
                    Street = "Boots 193",
                    PostalCode = "W1F 8SR"
                }
            }
        ];

        return restaurants;
    }
}