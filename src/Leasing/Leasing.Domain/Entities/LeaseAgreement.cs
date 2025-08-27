using ApartmentManagementSystem.SharedKernel.Entitites;
using ApartmentManagementSystem.SharedKernel.Enum;
using Leasing.Domain.DomainEvents;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class LeaseAgreement : Entity
    {
        public LeaseAgreementId Id { get; private set; } = null!;
        public TenantId TenantId { get; private set; } = null!;
        public Tenant Tenant { get; private set; } = null!;
        public ApartmentId ApartmentId { get; private set; } = null!;
        public Apartment Apartment { get; private set; } = null!;
        public double MonthlyRent { get; private set; }
        public LeaseTerm LeaseTermInMonths { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public LeaseStatus Status { get; private set; } = LeaseStatus.Created;

        protected LeaseAgreement() { }
        
        private LeaseAgreement(
            LeaseAgreementId leaseAgreementId,
            TenantId tenantId,
            ApartmentId apartmentId,
            DateTime dateStart,
            LeaseTerm leaseTerm,
            double monthlyRent,
            DateTime? now = null)
        {
            Id = leaseAgreementId;
            TenantId = tenantId;
            ApartmentId = apartmentId;
            DateCreated = DateTime.UtcNow;
            DateStart = dateStart;
            LeaseTermInMonths = leaseTerm;
            DateEnd = dateStart.AddMonths((int)LeaseTermInMonths);
            MonthlyRent = monthlyRent;
            EnsureStatusUpToDate(now ?? DateTime.UtcNow);
        }


        public static LeaseAgreement Create(
            TenantId tenantId,
            ApartmentId apartmentId,
            DateTime dateStart,
            LeaseTerm leaseTerm,
            double monthlyRent,
            DateTime? now = null)
        {
            var leaseAgreement = new LeaseAgreement(new LeaseAgreementId(Guid.NewGuid()),
                               tenantId,
                               apartmentId,
                               dateStart,
                               leaseTerm,
                               monthlyRent,
                               now);

            leaseAgreement.RaiseDomainEvent(new LeaseAgreementCreatedEvent(leaseAgreement));
            return leaseAgreement;
        }


        public void EnsureStatusUpToDate(DateTime now)
        {
            var today = now.Date;
            if (Status == LeaseStatus.Terminated)
                return;

            if (today < DateStart.Date)
                Status = LeaseStatus.Created;
            else if (today >= DateEnd.Date)
                Status = LeaseStatus.Ended;
            else
                Status = LeaseStatus.Active;
        }

     
        public void Terminate()
        {
            if (Status == LeaseStatus.Ended) return;
            Status = LeaseStatus.Terminated;
        }
    }
}
