using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ownership.Domain.Entities;
using Ownership.Domain.ValueObjects;

namespace Ownership.Infrastracture.Data.Configuration
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
