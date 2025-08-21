using Property.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Property.Domain.Entities
{
    public class OwnerEntity
    {
        public OwnerEntityId Id { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public List<Unit> Unit { get; set; } = [];

    }
}
