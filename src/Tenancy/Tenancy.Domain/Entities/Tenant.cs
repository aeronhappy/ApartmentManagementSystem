using ApartmentManagementSystem.SharedKernel.Entitites;
using Tenancy.Domain.DomainEvents;
using Tenancy.Domain.ValueObjects;

namespace Tenancy.Domain.Entities
{
    public class Tenant : Entity
    {
        public TenantId Id { get; set; } = null!;
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
        public static Tenant Create(Guid id,string email ,string name, string address,int gender, string contactNumber)
        {
            var tenant = new Tenant(new TenantId(id), email, name, address, gender, contactNumber);
            tenant.RaiseDomainEvent(new TenantCreatedEvent(tenant));
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
