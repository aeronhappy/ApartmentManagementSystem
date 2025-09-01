using ApartmentManagementSystem.Contracts.Services;
using MediatR;
using Property.Domain.DomainEvents;
using Property.IntegrationEvent;

namespace Property.Application.EventHandler.Domain
{


    public class AssignedOwnerToApartmentEventHandler : INotificationHandler<AssignedOwnerToApartmentEvent>
    {
        private readonly IEventBus _eventBus;

        public AssignedOwnerToApartmentEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(AssignedOwnerToApartmentEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new AssignedOwnerToApartmentIntegrationEvent
                                        (   
                                            notification.OwnerId,
                                            notification.Apartment.Id.Value,
                                            notification.Apartment.BuildingId.Value,
                                            notification.Apartment.Building.Name,
                                            notification.Apartment.Name,
                                            notification.Apartment.Number,
                                            notification.Apartment.Floor,
                                            notification.Apartment.AreaSqm,
                                            notification.Apartment.Status
                                         );

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
