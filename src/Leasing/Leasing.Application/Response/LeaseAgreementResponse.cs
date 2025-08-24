using ApartmentManagementSystem.SharedKernel.Enum;

namespace Leasing.Application.Response
{
    public class LeaseAgreementResponse
    {
        public Guid Id { get; private set; }
        public TenantResponse Tenant { get; private set; } = null!;
        //public Unit Unit { get; private set; } = null!;
        public double MonthlyRent { get; private set; }
        public LeaseTerm LeaseTermInMonths { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public LeaseStatus LeaseStatus { get; private set; } = LeaseStatus.Created;
    }
  
}
