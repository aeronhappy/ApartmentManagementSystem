using Ownership.Domain.Entities;
using Ownership.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class Building
    {
        public BuildingId Id { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int FloorCount { get; set; }
        public List<Unit> Unit { get; set; } = [];
    }
}
