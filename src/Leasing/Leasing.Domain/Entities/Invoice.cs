using ApartmentManagementSystem.SharedKernel.Enum;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class Invoice
    {
        public InvoiceId Id { get; private set; } = null!;
        public LeaseAgreementId LeaseAgreementId { get; private set; } = null!;
        public LeaseAgreement LeaseAgreement { get; private set; } = null!;
        public DateTime DatePeriod { get; private set; }
        public double Amount { get; private set; }
        public InvoiceStatus Status { get; private set; }
        public PaymentReceipt? PaymentReceipt { get; private set; }

        protected Invoice() { }

        private Invoice(InvoiceId id, LeaseAgreementId leaseAgreementId, DateTime datePeriod, double amount)
        {
            Id = id;
            LeaseAgreementId = leaseAgreementId;
            DatePeriod = datePeriod;
            Amount = amount;
            Status = InvoiceStatus.Open;
        }

        public static Invoice Create(Guid leaseAgreementId, DateTime datePeriod, double amount)
        {
            return new Invoice(new InvoiceId(Guid.NewGuid()), new LeaseAgreementId(leaseAgreementId), datePeriod, amount);
        }

        public void AttachReceipt(PaymentReceipt receipt)
        {
           
            if (receipt is null) 
                throw new ArgumentNullException(nameof(receipt));

            if (receipt.InvoiceId.Value != Id.Value)
                throw new InvalidOperationException("Receipt.InvoiceId must match Invoice.Id.");

            PaymentReceipt = receipt;
            Status = InvoiceStatus.Paid;
        }
    }
}
