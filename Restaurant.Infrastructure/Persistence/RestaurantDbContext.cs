using Restaurant.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Infrastructure.Persistence;

public class RestaurantDbContext : DbContext
{
    public DbSet<Domain.Entities.Restaurant> Restaurants { get; set; } = null!;
    public DbSet<Dish> Dishes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=TAOSIF\\SQLEXPRESS;Database=ToyProject_02_RestaurantDB;TrustServerCertificate=True;Trusted_Connection=True");
        //base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Domain.Entities.Restaurant>()
            .OwnsOne(x => x.Address);
    }
}