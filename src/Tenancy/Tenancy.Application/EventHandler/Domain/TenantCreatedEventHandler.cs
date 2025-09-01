using ApartmentManagementSystem.Contracts.Services;
using MediatR;
using Tenancy.Domain.DomainEvents;
using Tenancy.IntegrationEvent;

namespace Tenancy.Application.EventHandler.Domain
{

    public class TenantCreatedEventHandler : INotificationHandler<TenantCreatedEvent>
    {
        private readonly IEventBus _eventBus;

        public TenantCreatedEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(TenantCreatedEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new TenantCreatedIntegrationEvent
                (
                    notification.Tenant.Id.Value,
                    notification.Tenant.Email,
                    notification.Tenant.Name
                );

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
