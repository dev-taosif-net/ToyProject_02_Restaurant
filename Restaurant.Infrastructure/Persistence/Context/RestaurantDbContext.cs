using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Persistence.Context;

internal class RestaurantDbContext : DbContext
{
    internal DbSet<Domain.Entities.Restaurant> Restaurants { get; set; } = null!;
    internal DbSet<Dish> Dishes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=TAOSIF\\SQLEXPRESS;Database=ToyProject_02_RestaurantDB;TrustServerCertificate=True;Trusted_Connection=True");
        //base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestaurantDbContext).Assembly);
        
    }
}