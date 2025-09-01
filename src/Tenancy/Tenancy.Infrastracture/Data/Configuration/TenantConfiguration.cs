using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tenancy.Domain.Entities;
using Tenancy.Domain.ValueObjects;

namespace Tenancy.Infrastracture.Data.Configuration
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> tenant)
        {

            tenant.HasKey(t => t.Id);

            tenant.Property(t => t.Id)
                .HasConversion(
                    o => o.Value,
                    value => new TenantId(value));

        }
    }
}
