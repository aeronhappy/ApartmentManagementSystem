using ApartmentManagementSystem.SharedKernel;

namespace Tenancy.IntegrationEvent
{
    public record TenantCreatedIntegrationEvent
        (
            Guid TenantId,
            string Email,
            string Name
        ) : IIntegrationEvent;
   
}
