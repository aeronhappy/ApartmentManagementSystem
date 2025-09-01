using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leasing.Infrastracture.Data.Configuration
{
    public class LeaseAgreementConfiguration : IEntityTypeConfiguration<LeaseAgreement>
    {
        public void Configure(EntityTypeBuilder<LeaseAgreement> leaseAgreement)
        {
            leaseAgreement.HasKey(u => u.Id);
            leaseAgreement.Property(u => u.Id)
                .HasConversion(u => u.Value, value => new LeaseAgreementId(value));

            leaseAgreement.Property(u => u.TenantId)
                .HasConversion(u => u.Value, value => new TenantId(value));

            leaseAgreement.Property(u => u.ApartmentId)
                .HasConversion(u => u!.Value, value => new ApartmentId(value));

            leaseAgreement.HasMany(l => l.Invoices)
                .WithOne(i => i.LeaseAgreement)
                .HasForeignKey(i => i.LeaseAgreementId);

        }
    }
}
