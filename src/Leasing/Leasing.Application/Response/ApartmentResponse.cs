using ApartmentManagementSystem.SharedKernel.Enum;
using Leasing.Domain.ValueObjects;

namespace Leasing.Application.Response
{

    public class ApartmentResponse
    {
        public required Guid Id { get; set; } 
        public required Guid BuildingId { get; set; }
        public required string BuildingName { get; set; }
        public string Name { get; private set; } = string.Empty;
        public int Number { get; private set; }
        public int Floor { get; set; } = 0;
        public int AreaSqm { get; set; } = 0;
        public ApartmentStatus Status { get; set; } = ApartmentStatus.Vacant;


    }


}
