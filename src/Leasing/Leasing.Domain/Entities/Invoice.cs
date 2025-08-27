using Leasing.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Leasing.Domain.Entities
{
    public class Invoice
    {
        public InvoiceId Id { get; set; } = null!;
        public LeaseAgreementId LeaseAgreementId { get; set; }
        public LeaseAgreement LeaseAgreement { get; set; }
        public DateTime DatePeriod { get; set; }
        public double Amount { get; set; }
        public double Amount { get; set; }


        protected Invoice() { }

        // Private Tenantconstructor
        private Invoice(TenantId id,string email, string name, string address,int gender, string contactNumber)
        {
            Id = id;
            Email = email;
            Name = name;
            Address = address;
            Gender = gender;
            ContactNumber = contactNumber;
        }


        // Factory method to create a Tenant
        public static Invoice Create(Guid id,string email ,string name, string address,int gender, string contactNumber)
        {
            var tenant = new Invoice(new TenantId(id), email,  name, address, gender, contactNumber);
            return tenant;
        }

        public void Update(string name, string address, string contactNumber)
        {
            Name = name;
            Address = address;
            ContactNumber = contactNumber;
        }

    }
}
