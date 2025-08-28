using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leasing.Infrastracture.Data.Configuration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> invoice)
        {

            invoice.HasKey(t => t.Id);

            invoice.Property(t => t.Id)
                .HasConversion(
                    o => o.Value,
                    value => new InvoiceId(value));

            invoice.Property(t => t.LeaseAgreementId)
              .HasConversion(
                  o => o.Value,
                  value => new LeaseAgreementId(value));

            invoice.HasOne(a => a.LeaseAgreement)
             .WithMany(l => l.Invoices)
             .HasForeignKey(a => a.LeaseAgreementId)
             .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
