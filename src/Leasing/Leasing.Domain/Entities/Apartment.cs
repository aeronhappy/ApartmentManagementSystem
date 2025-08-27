using ApartmentManagementSystem.SharedKernel.Enum;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{

    public class Apartment
    {
        public ApartmentId Id { get; set; } = null!;
        public required Guid BuildingId { get; set; }
        public required string BuildingName { get; set; }
        public required string Name { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; } = 0;
        public int AreaSqm { get; set; } = 0;
        public ApartmentStatus Status { get; set; } = ApartmentStatus.Vacant;

    }


}
