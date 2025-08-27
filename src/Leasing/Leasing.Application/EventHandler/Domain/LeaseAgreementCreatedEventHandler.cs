using ApartmentManagementSystem.Contracts.Services;
using Leasing.Domain.DomainEvents;
using Leasing.IntegrationEvent;
using MediatR;

namespace Leasing.Application.EventHandler.Domain
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
            var integrationEvent = new LeaseAgreementCreatedIntegrationEvent
                (
                    notification.LeaseAgreement.Id.Value,
                    notification.LeaseAgreement.TenantId.Value,
                    notification.LeaseAgreement.Tenant.Name,
                    notification.LeaseAgreement.ApartmentId.Value,
                    notification.LeaseAgreement.MonthlyRent,
                    notification.LeaseAgreement.LeaseTermInMonths,
                    notification.LeaseAgreement.DateCreated,
                    notification.LeaseAgreement.DateStart,
                    notification.LeaseAgreement.DateEnd,
                    notification.LeaseAgreement.Status
                );
            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
