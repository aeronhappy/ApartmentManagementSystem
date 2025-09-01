using ApartmentManagementSystem.SharedKernel.Enum;

namespace Ownership.Application.Response
{
    public class ApartmentResponse
    {
        public Guid Id { get; private set; }
        public Guid BuildingId { get; private set; }
        public string BuildingName { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public int Number { get; private set; } 
        public int Floor { get; private set; }
        public int AreaSqm { get; private set; }
        public ApartmentStatus Status { get; private set; } = ApartmentStatus.Vacant;

    }

}
