using ApartmentManagementSystem.SharedKernel.Enum;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Application.Response
{
    public class ApartmentResponse
    {
        public Guid Id { get; private set; }
        public BuildingResponseWithoutApartments Building { get; private set; } = null!;
        public string Number { get; private set; } = null!;
        public int Floor { get; private set; }
        public int AreaSqm { get; private set; }
        public ApartmentStatus Status { get; private set; } = ApartmentStatus.Vacant;
        public OwnerResponseWithoutApartment? Owner { get; private set; } = null!;
        public LeaseAgreementResponseWihoutApartment? LeaseAgreement { get; private set; } = null!;

    }

    public class ApartmentResponseWithoutBuilding
    {
        public Guid Id { get; private set; }
        public string Number { get; private set; } = null!;
        public int Floor { get; private set; }
        public int AreaSqm { get; private set; }
    }
}
