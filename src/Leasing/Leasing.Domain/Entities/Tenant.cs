using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class Tenant
    {
        public TenantId Id { get; set; } = null!;
        public required string Email { get; set; }
        public required string Name { get; set; } 
    }
}
