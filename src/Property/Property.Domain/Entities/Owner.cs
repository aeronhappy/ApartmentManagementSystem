using Property.Domain.ValueObjects;

namespace Property.Domain.Entities
{
    public class Owner
    {
        public OwnerId Id { get; set; } = null!;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

    }
}
