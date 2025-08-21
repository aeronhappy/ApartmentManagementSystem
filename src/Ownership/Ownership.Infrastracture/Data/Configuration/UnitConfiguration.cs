using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ownership.Domain.Entities;
using Ownership.Domain.ValueObjects;

namespace Ownership.Infrastracture.Data.Configuration
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> unit)
        {
            unit.HasKey(u => u.Id);
            unit.Property(u => u.Id)
                .HasConversion(u => u.Value, value => new UnitId(value));

            unit.Property(u => u.BuildingId)
                .HasConversion(u => u.Value, value => new BuildingId(value));

            unit.Property(u => u.OwnerId)
                .HasConversion(u => u.Value, value => new OwnerId(value));

            unit.HasOne(u => u.Building)
                .WithMany(b => b.Unit)
                .HasForeignKey(u => u.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
