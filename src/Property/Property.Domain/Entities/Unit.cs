using Property.Domain.Enum;
using Property.Domain.ValueObjects;

namespace Property.Domain.Entities
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
        public OwnerId OwnerId { get; private set; } = null!;
        public Owner Owner { get; private set; } = null!;

        //public TenantId TenantId { get; private set; }

        protected Unit() { }

        //private constructor
        private Unit(UnitId id, BuildingId buildingid, string number, int floor, int areaSqm)
        {
            Id = id;
            BuildingId = buildingid;
            Number = number;
            Floor = floor;
            AreaSqm = areaSqm;
            Status = UnitStatus.Vacant;
        }

        //factory method to create a Unit
        public static Unit Create(Building building, int number, int floor, int areaSqm)
        {
            var user = new Unit(new UnitId(Guid.NewGuid()),
                               building.Id,
                               $"{building.Name}{floor}-{number}", 
                               floor, 
                               areaSqm);

            return user;
        }

        public void Update( int number, int floor, int areaSqm)
        {
            Number = $"{Building.Name}{floor}-{number}";
            Floor = floor;
            AreaSqm = areaSqm;
        }


    }
}
