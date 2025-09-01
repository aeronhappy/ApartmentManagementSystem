using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tenancy.Domain.Entities;
using Tenancy.Domain.ValueObjects;

namespace Tenancy.Infrastracture.Data.Configuration
{
    public class LeaseAgreementConfiguration : IEntityTypeConfiguration<LeaseAgreement>
    {
        public void Configure(EntityTypeBuilder<LeaseAgreement> leaseAgreement)
        {
            leaseAgreement.HasKey(u => u.Id);
            leaseAgreement.Property(u => u.Id)
                .HasConversion(u => u.Value, value => new LeaseAgreementId(value));
        }
    }
}
