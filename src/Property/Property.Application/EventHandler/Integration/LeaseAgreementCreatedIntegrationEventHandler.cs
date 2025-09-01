using Leasing.IntegrationEvent;
using MediatR;
using Property.Application.Commands;
using Property.Domain.Entities;
using Property.Domain.Repositories;
using Property.Domain.ValueObjects;

namespace Property.Application.EventHandler.Integration
{


    public class LeaseAgreementCreatedIntegrationEventHandler : INotificationHandler<LeaseAgreementCreatedIntegrationEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApartmentCommands _apartmentCommands;

        public LeaseAgreementCreatedIntegrationEventHandler(IUnitOfWork unitOfWork ,IApartmentCommands apartmentCommands)
        {
            _unitOfWork = unitOfWork;
            _apartmentCommands = apartmentCommands;
        }

        public async Task Handle(LeaseAgreementCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {

            if (notification == null)
                return;

            LeaseAgreement leaseAgreement = new()
            {
                Id = new LeaseAgreementId(notification.Id),
                TenantId = notification.TenantId,
                TenantName  = notification.TenantName,
                ApartmentId= new ApartmentId(notification.ApartmentId),
                MonthlyRent = notification.MonthlyRent,
                LeaseTermInMonths = notification.LeaseTermInMonths,
                DateCreated = notification.DateCreated,
                DateStart = notification.DateStart,
                DateEnd = notification.DateEnd,
                Status = notification.Status,
            };

            await _apartmentCommands.AddLeaseAgreementAsync(notification.ApartmentId,
                                                           leaseAgreement,
                                                            cancellationToken);

        }
    }
}
