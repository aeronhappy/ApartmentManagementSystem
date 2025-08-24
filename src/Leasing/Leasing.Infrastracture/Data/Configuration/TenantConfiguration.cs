using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leasing.Infrastracture.Data.Configuration
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> tenant)
        {

            tenant.HasKey(o => o.Id);
            tenant.Property(o => o.Id)
                .HasConversion(
                    o => o.Value,
                    value => new TenantId(value));
           

        }
    }
}
