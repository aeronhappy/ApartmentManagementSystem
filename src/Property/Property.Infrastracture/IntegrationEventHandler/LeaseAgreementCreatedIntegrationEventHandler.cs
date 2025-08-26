using Leasing.IntegrationEvent;
using MediatR;
using Property.Application.Commands;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;
using Property.Infrastracture.Data;

namespace Property.Infrastracture.IntegrationEventHandler
{


    public class LeaseAgreementCreatedIntegrationEventHandler : INotificationHandler<LeaseAgreementCreatedIntegrationEvent>
    {
        private readonly PropertyDbContext _context;
        private readonly IApartmentCommands _apartmentCommand;

        public LeaseAgreementCreatedIntegrationEventHandler(PropertyDbContext context, IApartmentCommands apartmentCommand)
        {
            _context = context;
            _apartmentCommand = apartmentCommand;
        }

        public async Task Handle(LeaseAgreementCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {

            if (notification?.LeaseAgreement == null)
                return;

            LeaseAgreement leaseAgreement = new()
            {
                Id = new LeaseAgreementId(notification.LeaseAgreement.Id.Value),
                TenantId = notification.LeaseAgreement.TenantId.Value,
                TenantName  = notification.LeaseAgreement.Tenant.Name,
                MonthlyRent = notification.LeaseAgreement.MonthlyRent,
                LeaseTermInMonths = notification.LeaseAgreement.LeaseTermInMonths,
                DateCreated = notification.LeaseAgreement.DateCreated,
                DateStart = notification.LeaseAgreement.DateStart,
                DateEnd = notification.LeaseAgreement.DateEnd,
                LeaseStatus = notification.LeaseAgreement.LeaseStatus,

            };

            await _apartmentCommand.AddLeaseAgreementAsync(notification.LeaseAgreement.ApartmentId.Value,
                                                           notification.LeaseAgreement.Id.Value, 
                                                           cancellationToken);
            await _context.LeaseAgreements.AddAsync(leaseAgreement, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
