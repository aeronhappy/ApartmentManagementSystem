using ApartmentManagementSystem.SharedKernel.Enum;
using Property.Domain.ValueObjects;

namespace Property.Domain.Entities
{
    public class LeaseAgreement
    {
        public LeaseAgreementId Id { get;  set; } = null!;
        public required Guid TenantId { get; set; }
        public required string TenantName { get; set; }
        public ApartmentId ApartmentId { get; set; } = null!;
        public Apartment Apartment { get; set; } = null!;
        public double MonthlyRent { get;  set; }
        public LeaseTerm LeaseTermInMonths { get;  set; }
        public DateTime DateCreated { get;  set; }
        public DateTime DateStart { get;  set; }
        public DateTime DateEnd { get;  set; }
        public LeaseStatus Status { get;  set; } = LeaseStatus.Created;

    }
}
