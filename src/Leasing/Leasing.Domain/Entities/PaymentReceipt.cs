using ApartmentManagementSystem.SharedKernel.Enum;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class PaymentReceipt
    {
        public PaymentReceiptId Id { get; private set; } = null!;
        public InvoiceId InvoiceId { get; private set; } = null!;
        public Invoice Invoice { get; private set; } = null!;

        public double AmountPaid { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public string ReferenceNumber { get; private set; } = string.Empty;

        protected PaymentReceipt() { }

        public static string GenerateRefNumber()
        {
            var datePart = DateTime.UtcNow.ToString("yyyyMMdd");
            var random = new Random();
            var randomPart = random.Next(100000, 999999);
            return $"{datePart}-{randomPart}";
        }

        private PaymentReceipt(PaymentReceiptId id, InvoiceId invoiceId, double amountPaid, PaymentMethod paymentMethod)
        {
            Id = id;
            InvoiceId = invoiceId;
            AmountPaid = amountPaid;
            PaymentDate = DateTime.UtcNow;
            PaymentMethod = paymentMethod;
            ReferenceNumber = GenerateRefNumber();
        }

        public static PaymentReceipt Create(Guid invoiceId, double amountPaid, PaymentMethod paymentMethod)
        {
            return new PaymentReceipt(
                new PaymentReceiptId(Guid.NewGuid()),
                new InvoiceId(invoiceId),
                amountPaid,
                paymentMethod
            );
        }
    }
}
