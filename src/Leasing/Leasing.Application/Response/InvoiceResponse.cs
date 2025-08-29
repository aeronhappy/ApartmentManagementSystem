using ApartmentManagementSystem.SharedKernel.Enum;
using Leasing.Domain.Entities;

namespace Leasing.Application.Response
{
    public class InvoiceResponse
    {
        public Guid Id { get; set; }
        public LeaseAgreementResponseWithoutInvoices LeaseAgreement { get; set; } = null!;
        public DateTime DatePeriod { get; set; }
        public double Amount { get; set; }
        public InvoiceStatus Status { get; set; }
        public PaymentReceiptResponseWithoutInvoice? PaymentReceipt { get; set; }
    }

    public class InvoiceResponseWithoutLeaseAgreement
    {
        public Guid Id { get; set; }
        public DateTime DatePeriod { get; set; }
        public double Amount { get; set; }
        public InvoiceStatus Status { get; set; }
        public PaymentReceiptResponseWithoutInvoice? PaymentReceipt { get; set; }
    }
    public class InvoiceResponseWithoutPaymentReceipt
    {
        public Guid Id { get; set; }
        public DateTime DatePeriod { get; set; }
        public double Amount { get; set; }
        public InvoiceStatus Status { get; set; }
    }

}
