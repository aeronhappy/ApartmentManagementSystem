using ApartmentManagementSystem.SharedKernel.Entitites;
using ApartmentManagementSystem.SharedKernel.Enum;
using Tenancy.Domain.ValueObjects;

namespace Tenancy.Domain.Entities
{
    public class LeaseAgreement : Entity
    {
        public LeaseAgreementId Id { get; set; } = null!;
        public Guid ApartmentId { get; set; }
        public string ApartmentName { get; set; } = null!;
        public double MonthlyRent { get; set; }
        public LeaseTerm LeaseTermInMonths { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public LeaseStatus Status { get; set; } = LeaseStatus.Created;


    }
}
