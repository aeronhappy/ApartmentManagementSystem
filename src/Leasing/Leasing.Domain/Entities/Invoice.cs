using ApartmentManagementSystem.SharedKernel.Enum;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class Invoice
    {
        public InvoiceId Id { get; set; } = null!;
        public LeaseAgreementId LeaseAgreementId { get; set; } = null!;
        public LeaseAgreement LeaseAgreement { get; set; } = null!;
        public DateTime DatePeriod { get; set; } 
        public double Amount { get; set; }
        public InvoiceStatus Status { get; set; }

        //public PaymentReceipt? PaymentReceipt { get; set; }

        protected Invoice() { }

        // Private Invoiceconstructor
        private Invoice(InvoiceId id, LeaseAgreementId leaseAgreementId , DateTime datePeriod, double amount)
        {
            Id = id;
            LeaseAgreementId = leaseAgreementId;
            DatePeriod = datePeriod;
            Amount = amount;
            Status = InvoiceStatus.Open;
        }


        // Factory method to create a Invoice
        public static Invoice Create(Guid leaseAgreementId, DateTime datePeriod ,double amount)
        {
            var invoice = new Invoice(new InvoiceId(Guid.NewGuid()), new LeaseAgreementId(leaseAgreementId),  datePeriod, amount);
            return invoice;
        }

    }
}
