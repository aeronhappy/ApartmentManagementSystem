using ApartmentManagementSystem.SharedKernel.Enum;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class PaymentReceipt
    {
        public PaymentReceiptId Id { get; set; } = null!;
        public InvoiceId InvoiceId { get; set; } = null!;
        public Invoice Invoice { get; set; } = null!;
        public double AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; } 
        public string ReferenceNumber { get; set; } = string.Empty;


        protected PaymentReceipt() { }

        public static string GenerateRefNumber()
        {
            var datePart = DateTime.UtcNow.ToString("yyyyMMdd");
            var random = new Random();
            var randomPart = random.Next(100000, 999999); 
            return $"{datePart}-{randomPart}";
        }

        // Private PaymentReceipt constructor
        private PaymentReceipt(PaymentReceiptId id, InvoiceId invoiceId ,double amountPaid, PaymentMethod paymentMethod)
        {
            Id = id;
            InvoiceId = invoiceId;
            AmountPaid = amountPaid;
            PaymentDate = DateTime.UtcNow;
            PaymentMethod = paymentMethod;
            ReferenceNumber = GenerateRefNumber();
        }


        // Factory method to create a Invoice
        public static PaymentReceipt Create(Guid invoiceId, double amountPaid, PaymentMethod paymentMethod)
        {
            var paymentReceipt = new PaymentReceipt(
                new PaymentReceiptId(Guid.NewGuid()),
                new InvoiceId(invoiceId), 
                amountPaid,
                paymentMethod);

            return paymentReceipt;
        }

    }
}
