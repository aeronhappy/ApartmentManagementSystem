using ApartmentManagementSystem.SharedKernel.Enum;

namespace Leasing.Controller.Request
{
    public class CreatePaymentRequest
    {
        public Guid InvoiceId { get; set; }
        public Guid TenantId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
