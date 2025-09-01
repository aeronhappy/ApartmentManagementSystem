using ApartmentManagementSystem.SharedKernel.Enum;

namespace Tenancy.Application.Response
{
    public class LeaseAgreementResponse
    {
        public Guid Id { get; private set; }
        public Guid ApartmentId { get; private set; }
        public string ApartmentName { get; private set; } = null!;
        public double MonthlyRent { get; private set; }
        public LeaseTerm LeaseTermInMonths { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public LeaseStatus Status { get; private set; } = LeaseStatus.Created;
    }


}
