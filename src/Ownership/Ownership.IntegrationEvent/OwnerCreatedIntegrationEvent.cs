using ApartmentManagementSystem.SharedKernel;

namespace Ownership.IntegrationEvent
{
    public record OwnerCreatedIntegrationEvent
        (
            Guid OwnerId,
            string Email,
            string Name
        ) : IIntegrationEvent;
   
}
