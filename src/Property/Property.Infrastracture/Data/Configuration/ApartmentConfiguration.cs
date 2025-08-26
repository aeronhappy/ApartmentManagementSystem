using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Infrastracture.Data.Configuration
{
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> apartment)
        {
            apartment.HasKey(u => u.Id);
            apartment.Property(u => u.Id)
                .HasConversion(u => u.Value, value => new ApartmentId(value));

            apartment.Property(u => u.BuildingId)
                .HasConversion(u => u.Value, value => new BuildingId(value));

            apartment.Property(u => u.OwnerId)
                .HasConversion(u => u!.Value, value => new OwnerId(value));

            apartment.Property(u => u.LeaseAgreementId)
                .HasConversion(u => u!.Value, value => new LeaseAgreementId(value));

            apartment.HasOne(u => u.Building)
                .WithMany(b => b.Apartments)
                .HasForeignKey(u => u.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
