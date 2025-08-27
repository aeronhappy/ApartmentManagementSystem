using ApartmentManagementSystem.Contracts.Services;
using MediatR;
using Property.Domain.DomainEvents;
using Property.IntegrationEvent;

namespace Property.Application.EventHandler.Domain
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
            var integrationEvent = new ApartmentCreatedIntegrationEvent
                                        (
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
