using ApartmentManagementSystem.SharedKernel;

namespace Identity.IntegrationEvent
{
    public record UserCreatedIntegrationEvent
        (
            Guid Id,
            string Email,
            string Name,
            string Address,
            int Gender, 
            string ContactNumber,
            string Role

        ) : IIntegrationEvent;
   
}
