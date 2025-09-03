using ApartmentManagementSystem.SharedKernel.Entitites;
using ApartmentManagementSystem.SharedKernel.Enum;
using Property.Domain.DomainEvents;
using Property.Domain.Exception;
using Property.Domain.ValueObjects;

namespace Property.Domain.Entities
{

    public class Apartment : Entity
    {
        public ApartmentId Id { get; private set; } = null!;
        public BuildingId BuildingId { get; private set; } = null!;
        public Building Building { get; private set; } = null!;
        public string Name { get; private set; } = string.Empty;
        public int Number { get; private set; } = 0;
        public int Floor { get; private set; } = 0;
        public int AreaSqm { get; private set; } = 0;
        public ApartmentStatus Status { get; private set; } = ApartmentStatus.Vacant;
        public OwnerId? OwnerId { get; private set; } = null!;
        public Owner? Owner { get; private set; } = null!;
        public LeaseAgreementId? LeaseAgreementId { get; private set; }
        public LeaseAgreement? LeaseAgreement { get; private set; } = null!;

        protected Apartment() { }

        //private constructor
        private Apartment(ApartmentId id, BuildingId buildingid,string name, int number, int floor, int areaSqm)
        {
            Id = id;
            BuildingId = buildingid;
            Name = name;
            Number = number;
            Floor = floor;
            AreaSqm = areaSqm;
            Status = ApartmentStatus.Vacant;
        }

        static string BuildApartmentCode(string buildingName, int f, int n) => $"{buildingName}{f}-{n}";
        private static bool IsActive(LeaseStatus status) =>
                                     status != LeaseStatus.Ended && status != LeaseStatus.Terminated;

        //factory method to create a Unit
        public static Apartment Create(Building building, int number, int floor, int areaSqm)
        {
            if (building is null) throw new ArgumentNullException(nameof(building));
            if (number <= 0) throw new ArgumentOutOfRangeException(nameof(number), "Unit number must be positive.");
            if (floor <= 0) throw new ArgumentOutOfRangeException(nameof(floor), "Floor must be positive.");
            if (areaSqm <= 0) throw new ArgumentOutOfRangeException(nameof(areaSqm), "Area (sqm) must be positive.");

            var existsOnSameFloor = building.Apartments.Any(a => a.Floor == floor && a.Number == number);
            if (existsOnSameFloor)
                throw new UnitNumberIsAlreadyTakenInSameFloorException(
                    "Cannot use the same unit number on the same floor.");

            var apartment = new Apartment(
                new ApartmentId(Guid.NewGuid()),
                building.Id,
                BuildApartmentCode(building.Name, floor, number),
                number,
                floor,
                areaSqm);

            apartment.RaiseDomainEvent(new ApartmentCreatedEvent(apartment));
            return apartment;

           
        }
      
        public void Update(int number, int floor, int areaSqm)
        {
            if (number <= 0) throw new ArgumentOutOfRangeException(nameof(number), "Unit number must be positive.");
            if (floor <= 0) throw new ArgumentOutOfRangeException(nameof(floor), "Floor must be positive.");
            if (areaSqm <= 0) throw new ArgumentOutOfRangeException(nameof(areaSqm), "Area (sqm) must be positive.");

            var existsOnSameFloor = Building.Apartments.Any(a => a.Floor == floor && a.Number == number);
            if (existsOnSameFloor)
                throw new UnitNumberIsAlreadyTakenInSameFloorException(
                    "Cannot use the same unit number on the same floor.");

            Number = number;
            Floor = floor;
            AreaSqm = areaSqm;
            BuildApartmentCode(Building.Name, floor, number);
        }

        public void AssignOwner(Apartment apartment, OwnerId ownerId)
        {
            if (OwnerId is not null)
                throw new HasOwnerAlreadyException("This apartment has owner already.");

            OwnerId = ownerId;
            apartment.RaiseDomainEvent(new AssignedOwnerToApartmentEvent(apartment, ownerId.Value));

        }

        public void RemoveOwner(Apartment apartment, OwnerId ownerId)
        {
            if(OwnerId is null)
                throw new NoOwnerException("You can't remove Owner in apartment that no owner.");

            OwnerId = null;
            apartment.RaiseDomainEvent(new RemoveOwnerToApartmentEvent(apartment, ownerId.Value));
        }

        public void AddLeaseAgreement(LeaseAgreement leaseAgreement)
        {
            if (leaseAgreement is null)
                throw new ArgumentNullException(nameof(leaseAgreement));

            if (LeaseAgreement is not null && IsActive(LeaseAgreement.Status))
                throw new OccupiedStatusCannotChangeException("This apartment already has an active lease.");

            if (Status == ApartmentStatus.Occupied)
                throw new OccupiedStatusCannotChangeException("This apartment is already occupied.");

            LeaseAgreementId = leaseAgreement.Id;
            LeaseAgreement = leaseAgreement;
            Status = ApartmentStatus.Occupied;
        }

        public void ChangeStatus(ApartmentStatus apartmentStatus)
        {
            if(Status == ApartmentStatus.Occupied)
            {
                throw new OccupiedStatusCannotChangeException(
                   "Cannot change the apartment status when occupied.");
            }
            Status = apartmentStatus;
        }

    }
}
