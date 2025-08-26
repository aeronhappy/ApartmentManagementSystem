using Leasing.Domain.ValueObjects;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Leasing.Domain.Entities
{
    public class Tenant
    {
        public TenantId Id { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Gender { get; set; }
        public string ContactNumber { get; set; } = string.Empty;
        public List<LeaseAgreement> LeaseAgreements { get; set; } = [];

        protected Tenant() { }

        // Private Tenantconstructor
        private Tenant(TenantId id,string email, string name, string address,int gender, string contactNumber)
        {
            Id = id;
            Email = email;
            Name = name;
            Address = address;
            Gender = gender;
            ContactNumber = contactNumber;
        }


        // Factory method to create a Tenant
        public static Tenant Create(string email ,string name, string address,int gender, string contactNumber)
        {
            var tenant = new Tenant(new TenantId(Guid.NewGuid()), email,  name, address, gender, contactNumber);
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
