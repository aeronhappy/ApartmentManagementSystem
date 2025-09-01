using ApartmentManagementSystem.SharedKernel;
using ApartmentManagementSystem.SharedKernel.Enum;

namespace Property.IntegrationEvent
{
    public record AssignedOwnerToApartmentIntegrationEvent
        (
            Guid OwnerId,
            Guid ApplicationId,
            Guid BuildingId,
            string BuildingName,
            string Name,
            int Number,
            int Floor,
            int AreaSqm,
            ApartmentStatus Status
        ) : IIntegrationEvent;
   
}
