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
            leaseAgreement.HasKey(l => l.Id);

            leaseAgreement.Property(l => l.Id)
                .HasConversion(o => o.Value, v => new LeaseAgreementId(v));

            leaseAgreement.Property(l => l.TenantId)
                .HasConversion(o => o.Value, v => new TenantId(v)); 
           
            leaseAgreement.Property(l => l.ApartmentId)
                .HasConversion(o => o.Value, v => new ApartmentId(v));

    
            leaseAgreement.HasMany(l => l.Invoices)
                .WithOne(i => i.LeaseAgreement)
                .HasForeignKey(i => i.LeaseAgreementId)
                .OnDelete(DeleteBehavior.Restrict);

            leaseAgreement.ToTable("LeaseAgreements", "Leasing");
        }
    }
}