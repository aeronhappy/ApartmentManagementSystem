using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Infrastracture.Data.Configuration
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> building)
        {

            building.HasKey(b => b.Id);
            building.Property(b => b.Id)
                .HasConversion(
                    b => b.Value,
                    value => new BuildingId(value));

            building.HasMany(b => b.Unit)
                .WithOne(u => u.Building) 
                .HasForeignKey(u => u.BuildingId);
        }
    }
}
