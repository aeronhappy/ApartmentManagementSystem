using ApartmentManagementSystem.SharedKernel.Enum;

namespace Property.Application.Response
{
    public class ApartmentResponse
    {
        public Guid Id { get; private set; }
        public BuildingResponseWithoutApartments Building { get; private set; } = null!;
        public string Name { get; private set; } = string.Empty;
        public int Number { get; private set; } 
        public int Floor { get; private set; }
        public int AreaSqm { get; private set; }
        public ApartmentStatus Status { get; private set; } = ApartmentStatus.Vacant;
        public OwnerResponseWithoutApartment? Owner { get; private set; } = null!;
        public LeaseAgreementResponseWihoutApartment? LeaseAgreement { get; private set; } = null!;

    }

    public class ApartmentResponseWithoutBuilding
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int Number { get; private set; }
        public int Floor { get; private set; }
        public int AreaSqm { get; private set; }
        public ApartmentStatus Status { get; private set; } = ApartmentStatus.Vacant;
        public OwnerResponseWithoutApartment? Owner { get; private set; } = null!;
        public LeaseAgreementResponseWihoutApartment? LeaseAgreement { get; private set; } = null!;
    }
}
