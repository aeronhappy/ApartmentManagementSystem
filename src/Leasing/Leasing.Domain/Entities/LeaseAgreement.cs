using ApartmentManagementSystem.SharedKernel.Entitites;
using ApartmentManagementSystem.SharedKernel.Enum;
using ApartmentManagementSystem.SharedKernel.ValueObject;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class LeaseAgreement
    {
        public LeaseAgreementId Id { get; private set; } = null!;
        public TenantId TenantId { get; private set; } = null!;
        public Tenant Tenant { get; private set; } = null!;
        public UnitId UnitId { get; private set; } = null!;
        public Unit Unit { get; private set; } = null!;
        public double MonthlyRent { get; private set; }
        public LeaseTerm LeaseTermInMonths { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public LeaseStatus LeaseStatus { get; private set; } = LeaseStatus.Created;

        protected LeaseAgreement() { }
        
        private LeaseAgreement(
            LeaseAgreementId leaseAgreementId,
            TenantId tenantId,
            UnitId unitId,
            DateTime dateStart,
            LeaseTerm leaseTerm,
            double monthlyRent,
            DateTime? now = null)
        {
            Id = leaseAgreementId;
            TenantId = tenantId;
            UnitId = unitId;
            DateCreated = DateTime.UtcNow;
            DateStart = dateStart;
            LeaseTermInMonths = leaseTerm;
            DateEnd = dateStart.AddMonths((int)LeaseTermInMonths);
            MonthlyRent = monthlyRent;
            EnsureStatusUpToDate(now ?? DateTime.UtcNow);
        }

       
        public static LeaseAgreement Create(
            TenantId tenantId,
            UnitId unitId,
            DateTime dateStart,
            LeaseTerm leaseTerm,
            double monthlyRent,
            DateTime? now = null)
        {
            return new LeaseAgreement(new LeaseAgreementId(Guid.NewGuid()),
                               tenantId,
                               unitId,
                               dateStart,
                               leaseTerm,
                               monthlyRent,
                               now);
        }

      
        public void EnsureStatusUpToDate(DateTime now)
        {
            var today = now.Date;
            if (LeaseStatus == LeaseStatus.Terminated)
                return;

            if (today < DateStart.Date)
                LeaseStatus = LeaseStatus.Created;
            else if (today >= DateEnd.Date)
                LeaseStatus = LeaseStatus.Ended;
            else
                LeaseStatus = LeaseStatus.Active;
        }

     
        public void Terminate()
        {
            if (LeaseStatus == LeaseStatus.Ended) return;
            LeaseStatus = LeaseStatus.Terminated;
        }
    }
}
