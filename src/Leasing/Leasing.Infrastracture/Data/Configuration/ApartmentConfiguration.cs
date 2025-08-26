using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leasing.Infrastracture.Data.Configuration
{
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> apartment)
        {
            apartment.HasKey(u => u.Id);
            apartment.Property(u => u.Id)
                .HasConversion(u => u.Value, value => new ApartmentId(value));

        }
    }
}
