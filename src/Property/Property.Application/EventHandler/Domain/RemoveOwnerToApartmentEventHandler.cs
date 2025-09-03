using ApartmentManagementSystem.Contracts.Services;
using MediatR;
using Property.Domain.DomainEvents;
using Property.IntegrationEvent;

namespace Property.Application.EventHandler.Domain
{


    public class RemoveOwnerToApartmentEventHandler : INotificationHandler<RemoveOwnerToApartmentEvent>
    {
        private readonly IEventBus _eventBus;

        public RemoveOwnerToApartmentEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(RemoveOwnerToApartmentEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new RemoveOwnerToApartmentIntegrationEvent
                                        (   
                                            notification.OwnerId,
                                            notification.Apartment.Id.Value
                                         );

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
