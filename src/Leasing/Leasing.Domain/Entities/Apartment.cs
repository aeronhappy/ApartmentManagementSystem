using ApartmentManagementSystem.SharedKernel.Enum;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{

    public class Apartment
    {
        public ApartmentId Id { get; set; } = null!;
        public required Guid BuildingId { get; set; }
        public required string BuildingName { get; set; }
        public string Number { get; set; } = string.Empty;
        public int Floor { get; set; } = 0;
        public int AreaSqm { get; set; } = 0;
        public ApartmentStatus Status { get; set; } = ApartmentStatus.Vacant;
        public required Guid? OwnerId { get; set; }
        public string? OwnerName { get; set; }

    }


}
