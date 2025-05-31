using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Restaurant.Infrastructure.Persistence.Configurations;

public class RestaurantConfiguration : IEntityTypeConfiguration<Domain.Entities.Restaurant>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Restaurant> builder)
    {
        builder.OwnsOne(x => x.Address);

        builder.HasMany(x => x.Dishes)
            
            .WithOne()
            .HasForeignKey(x => x.RestaurantId);
    }
}