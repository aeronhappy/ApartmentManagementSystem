using ApartmentManagementSystem.SharedKernel;
using Property.Domain.Entities;


namespace Property.Domain.DomainEvents
{
    public record ApartmentCreatedEvent(Apartment Apartment) : IDomainEvent;
  
}
