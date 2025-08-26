using ApartmentManagementSystem.Contracts.Services;
using Leasing.Domain.DomainEvents;
using Leasing.IntegrationEvent;
using MediatR;

namespace Leasing.Application.DomainEventHandler
{

    public class LeaseAgreementCreatedEventHandler : INotificationHandler<LeaseAgreementCreatedEvent>
    {
        private readonly IEventBus _eventBus;

        public LeaseAgreementCreatedEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(LeaseAgreementCreatedEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new LeaseAgreementCreatedIntegrationEvent(notification.LeaseAgreement);
            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
