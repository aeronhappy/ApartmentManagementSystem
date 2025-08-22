using Ownership.Domain.Entities;
using Ownership.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Leasing.Domain.Entities
{
    public class Owner
    {
        public OwnerId Id { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public List<Unit> Unit { get; set; } = [];

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
        public static Owner Create(string email ,string name, string address, string contactNumber)
        {
            var owner = new Owner(id: new OwnerId(Guid.NewGuid()), email: email, name: name, address: address, contactNumber: contactNumber);
            return owner;
        }

        public void Update(string name, string address, string contactNumber)
        {
            Name = name;
            Address = address;
            ContactNumber = contactNumber;
        }

        public void AddUnit(Unit unit)
        {
            Unit.Add(unit);
        }
    }
}
