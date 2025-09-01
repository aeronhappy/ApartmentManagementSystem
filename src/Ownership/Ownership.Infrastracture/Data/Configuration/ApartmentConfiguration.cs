using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ownership.Domain.Entities;
using Ownership.Domain.ValueObjects;

namespace Ownership.Infrastracture.Data.Configuration
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
