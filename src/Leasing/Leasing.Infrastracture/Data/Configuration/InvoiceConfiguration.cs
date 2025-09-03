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
                .HasConversion(o => o.Value, v => new InvoiceId(v));

            invoice.Property(t => t.LeaseAgreementId)
                .HasConversion(o => o.Value, v => new LeaseAgreementId(v));

            invoice.HasOne(i => i.LeaseAgreement)
                .WithMany(l => l.Invoices)
                .HasForeignKey(i => i.LeaseAgreementId)
                .OnDelete(DeleteBehavior.Restrict);

            invoice.HasOne(i => i.PaymentReceipt)
                .WithOne(r => r.Invoice)
                .HasForeignKey<PaymentReceipt>(r => r.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            invoice.ToTable("Invoices", "Leasing");
        }
    }
}
