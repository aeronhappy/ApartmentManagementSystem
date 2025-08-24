using ApartmentManagementSystem.SharedKernel.Enum;
using ApartmentManagementSystem.SharedKernel.ValueObject;

namespace ApartmentManagementSystem.SharedKernel.Entitites
{

    public class Unit
    {
        public UnitId Id { get; private set; } = null!;
        public BuildingId BuildingId { get; private set; } = null!;
        public Building Building { get; private set; } = null!;
        public string Number { get; private set; } = string.Empty;
        public int Floor { get; private set; } = 0;
        public int AreaSqm { get; private set; } = 0;
        public UnitStatus Status { get; private set; } = UnitStatus.Vacant;
        public OwnerId? OwnerId { get; private set; } = null!;
        public Owner? Owner { get; private set; } = null!;

        //public TenantId TenantId { get; private set; }

    }
}
