using ApartmentManagementSystem.SharedKernel.Entitites;
using ApartmentManagementSystem.SharedKernel.Enum;
using Property.Domain.DomainEvents;
using Property.Domain.ValueObjects;

namespace Property.Domain.Entities
{

    public class Apartment : Entity
    {
        public ApartmentId Id { get; private set; } = null!;
        public BuildingId BuildingId { get; private set; } = null!;
        public Building Building { get; private set; } = null!;
        public string Number { get; private set; } = string.Empty;
        public int Floor { get; private set; } = 0;
        public int AreaSqm { get; private set; } = 0;
        public ApartmentStatus Status { get; private set; } = ApartmentStatus.Vacant;
        public OwnerId? OwnerId { get; private set; } = null!;
        public Owner? Owner { get; private set; } = null!;
        public LeaseAgreementId? LeaseAgreementId { get; private set; }
        public LeaseAgreement? LeaseAgreement { get; private set; } = null!;

        protected Apartment() { }

        //private constructor
        private Apartment(ApartmentId id, BuildingId buildingid, string number, int floor, int areaSqm)
        {
            Id = id;
            BuildingId = buildingid;
            Number = number;
            Floor = floor;
            AreaSqm = areaSqm;
            Status = ApartmentStatus.Vacant;
        }

        //factory method to create a Unit
        public static Apartment Create(Building building, int number, int floor, int areaSqm)
        {
            var apartment = new Apartment(new ApartmentId(Guid.NewGuid()),
                               building.Id,
                               $"{building.Name}{floor}-{number}",
                               floor,
                               areaSqm);

            apartment.RaiseDomainEvent(new ApartmentCreatedEvent(apartment));
            return apartment;
        }

        public void Update(int number, int floor, int areaSqm)
        {
            Number = $"{Building.Name}{floor}-{number}";
            Floor = floor;
            AreaSqm = areaSqm;
        }

        public void AssignOwner(OwnerId ownerId)
        {
            OwnerId = ownerId;
        }

        public void AddLeaseAgreement(LeaseAgreementId leaseAgreementId)
        {
            LeaseAgreementId = leaseAgreementId;
            Status = ApartmentStatus.Occupied;
        }

        public void ChangeStatus(ApartmentStatus apartmentStatus)
        {
            Status = apartmentStatus;
        }

    }
}
