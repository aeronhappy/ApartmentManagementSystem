using ApartmentManagementSystem.SharedKernel.Enum;
using Leasing.Domain.Entities;

namespace Leasing.Application.Response
{
    public class LeaseAgreementResponse
    {
        public Guid Id { get; private set; }
        public TenantResponseWithoutLeaseAgreement Tenant { get; private set; } = null!;
        public ApartmentResponse Apartment { get; private set; } = null!;
        public double MonthlyRent { get; private set; }
        public LeaseTerm LeaseTermInMonths { get; private set; }
        public List<InvoiceResponse> Invoices { get; set; } = [];
        public DateTime DateCreated { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public LeaseStatus Status { get; private set; } = LeaseStatus.Created;
    }

    public class LeaseAgreementResponseWithoutTenant
    {
        public Guid Id { get; private set; }
        public ApartmentResponse Apartment { get; private set; } = null!;
        public double MonthlyRent { get; private set; }
        public LeaseTerm LeaseTermInMonths { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public LeaseStatus Status { get; private set; } = LeaseStatus.Created;
    }

}
