using ApartmentManagementSystem.SharedKernel.Enum;

namespace Property.Application.Response
{
    public class LeaseAgreementResponseWihoutApartment
    {
        public required Guid Id { get;  set; } 
        public required Guid TenantId { get;  set; }
        public required string TenantName { get; set; }
        public double MonthlyRent { get;  set; }
        public LeaseTerm LeaseTermInMonths { get;  set; }
        public DateTime DateCreated { get;  set; }
        public DateTime DateStart { get;  set; }
        public DateTime DateEnd { get;  set; }
        public LeaseStatus LeaseStatus { get;  set; } = LeaseStatus.Created;

    }
}
