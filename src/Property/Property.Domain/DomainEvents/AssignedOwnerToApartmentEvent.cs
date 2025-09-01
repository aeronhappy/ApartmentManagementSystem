using ApartmentManagementSystem.SharedKernel;
using Property.Domain.Entities;


namespace Property.Domain.DomainEvents
{
    public record AssignedOwnerToApartmentEvent(Apartment Apartment, Guid OwnerId) : IDomainEvent;
  
}
