using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leasing.Infrastracture.Data.Configuration
{
    public class PaymentReceiptConfiguration : IEntityTypeConfiguration<PaymentReceipt>
    {
        public void Configure(EntityTypeBuilder<PaymentReceipt> paymentReceipt)
        {
            paymentReceipt.HasKey(pr => pr.Id);

            paymentReceipt.Property(pr => pr.Id)
                .HasConversion(o => o.Value, v => new PaymentReceiptId(v));

            paymentReceipt.Property(pr => pr.InvoiceId)
                .HasConversion(o => o.Value, v => new InvoiceId(v));

            // Optional but recommended for 1:1 uniqueness at DB level
            paymentReceipt.HasIndex(pr => pr.InvoiceId).IsUnique();

            paymentReceipt.ToTable("PaymentReceipts", "Leasing");
        }
    }
}
