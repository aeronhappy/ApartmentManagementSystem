using ApartmentManagementSystem.SharedKernel.Entitites;
using Ownership.Domain.DomainEvents;
using Ownership.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Ownership.Domain.Entities
{
    public class Owner:Entity
    {
        public OwnerId Id { get; set; } = null!;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public List<Apartment> Apartments { get; set; } = [];

        protected Owner() { }

        // Private constructor
        private Owner(OwnerId id,string email, string name, string address, string contactNumber)
        {
            Id = id;
            Email = email;
            Name = name;
            Address = address;
            ContactNumber = contactNumber;
        }


        // Factory method to create a Building
        public static Owner Create(Guid id, string email ,string name, string address, string contactNumber)
        {
            var owner = new Owner(id: new OwnerId(id), email: email, name: name, address: address, contactNumber: contactNumber);
            owner.RaiseDomainEvent(new OwnerCreatedEvent(owner));
            return owner;
        }

        public void Update(string name, string address, string contactNumber)
        {
            Name = name;
            Address = address;
            ContactNumber = contactNumber;
        }

    }
}
