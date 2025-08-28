using ApartmentManagementSystem.SharedKernel.Enum;

namespace Leasing.Application.Response
{
    public class InvoiceResponse
    {
        public Guid Id { get; set; }
        public DateTime DatePeriod { get; set; }
        public double Amount { get; set; }
        public InvoiceStatus Status { get; set; }

    }


}
