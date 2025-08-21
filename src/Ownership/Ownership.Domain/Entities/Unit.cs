using Ownership.Domain.ValueObjects;
using Property.Domain.Entities;
using Property.Domain.Enum;
using Property.Domain.ValueObjects;

namespace Ownership.Domain.Entities
{

    public class Unit
    {
        public ValueObjects.UnitId Id { get; private set; } = null!;
        public ValueObjects.BuildingId BuildingId { get; private set; } = null!;
        public Building Building { get; private set; } = null!;
        public string Number { get; private set; } = string.Empty;
        public int Floor { get; private set; } = 0;
        public int AreaSqm { get; private set; } = 0;
        public UnitStatus Status { get; private set; } = UnitStatus.Vacant;
        public OwnerId OwnerId { get; private set; } = null!;
        public Owner Owner { get; private set; } = null!;

        //public TenantId TenantId { get; private set; }

    }
}
