using ApartmentManagementSystem.SharedKernel.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace ApartmentManagementSystem.SharedKernel.Entitites
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

    }
}
