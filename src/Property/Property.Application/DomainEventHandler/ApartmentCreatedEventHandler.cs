using ApartmentManagementSystem.Contracts.Services;
using MediatR;
using Property.Domain.DomainEvents;
using Property.IntegrationEvent;

namespace Property.Application.DomainEventHandler
{


    public class ApartmentCreatedEventHandler : INotificationHandler<ApartmentCreatedEvent>
    {
        private readonly IEventBus _eventBus;

        public ApartmentCreatedEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(ApartmentCreatedEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new ApartmentCreatedIntegrationEvent(notification.Apartment);
            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
