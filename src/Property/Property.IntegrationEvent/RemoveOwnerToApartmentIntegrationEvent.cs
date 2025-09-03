using ApartmentManagementSystem.SharedKernel;

namespace Property.IntegrationEvent
{
    public record RemoveOwnerToApartmentIntegrationEvent
        (
            Guid OwnerId,
            Guid ApartmentId
        ) : IIntegrationEvent;
   
}
