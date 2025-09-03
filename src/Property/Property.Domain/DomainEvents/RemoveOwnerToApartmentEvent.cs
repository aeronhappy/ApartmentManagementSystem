using ApartmentManagementSystem.SharedKernel;
using Property.Domain.Entities;


namespace Property.Domain.DomainEvents
{
    public record RemoveOwnerToApartmentEvent(Apartment Apartment, Guid OwnerId) : IDomainEvent;
  
}
