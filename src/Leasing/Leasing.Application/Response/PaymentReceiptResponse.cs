using ApartmentManagementSystem.SharedKernel.Enum;

namespace Leasing.Application.Response
{
    public class PaymentReceiptResponse
    {
        public Guid Id { get; set; }
        public InvoiceResponseWithoutPaymentReceipt Invoice { get; set; } = null!;
        public double AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
    }

    public class PaymentReceiptResponseWithoutInvoice
    {
        public Guid Id { get; set; }
        public double AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
    }


}
