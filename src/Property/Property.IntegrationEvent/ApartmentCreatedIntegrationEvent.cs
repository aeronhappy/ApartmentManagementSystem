using ApartmentManagementSystem.SharedKernel;
using Property.Domain.Entities;

namespace Property.IntegrationEvent
{
    public record ApartmentCreatedIntegrationEvent(Apartment Apartment) : IIntegrationEvent;
   
}
