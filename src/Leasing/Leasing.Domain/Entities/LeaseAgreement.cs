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
        public int LeaseTermInMonths { get; private set; }
        public List<Invoice> Invoices { get; set; } = [];
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
            int leaseTerm,
            double monthlyRent,
            DateTime? now = null)
        {
            Id = leaseAgreementId;
            TenantId = tenantId;
            ApartmentId = apartmentId;
            DateCreated = DateTime.UtcNow;
            DateStart = dateStart;
            LeaseTermInMonths = leaseTerm;

            for (int i = 0; i < LeaseTermInMonths; i++)
            {
                var invoiceDate = DateStart.AddMonths(i);
                var invoice = Invoice.Create(Id.Value, invoiceDate, monthlyRent);
                Invoices.Add(invoice);
            }

            DateEnd = dateStart.AddMonths(LeaseTermInMonths);
            MonthlyRent = monthlyRent;
            EnsureStatusUpToDate(now ?? DateTime.UtcNow);
        }


        public static LeaseAgreement Create(
            TenantId tenantId,
            ApartmentId apartmentId,
            DateTime dateStart,
            int leaseTerm,
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

            foreach(var item in Invoices)
            {
                if(item.Status == InvoiceStatus.Open)
                {
                    Invoices.Remove(item);
                }
            }
        }

        public void Renew(int leaseTerm)
        {
            if (Status == LeaseStatus.Terminated) return;

     
            var newLeastTerm = LeaseTermInMonths + leaseTerm;
            for (int i = 0; i < LeaseTermInMonths; i++)
            {
                var invoiceDate = DateStart.AddMonths(LeaseTermInMonths + i);
                var invoice = Invoice.Create(Id.Value, invoiceDate, MonthlyRent);
                Invoices.Add(invoice);
            }

            LeaseTermInMonths = newLeastTerm;
          

        }
    }
}
