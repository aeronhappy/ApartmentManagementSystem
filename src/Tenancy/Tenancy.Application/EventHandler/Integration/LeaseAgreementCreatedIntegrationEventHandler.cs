using Leasing.IntegrationEvent;
using MediatR;
using Tenancy.Domain.Entities;
using Tenancy.Domain.Repositories;
using Tenancy.Domain.ValueObjects;

namespace Tenancy.Application.EventHandler.Integration
{


    public class LeaseAgreementCreatedIntegrationEventHandler : INotificationHandler<LeaseAgreementCreatedIntegrationEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public LeaseAgreementCreatedIntegrationEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(LeaseAgreementCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {

            if (notification == null)
                return;


            LeaseAgreement leaseAgreement = new()
            {
                Id = new LeaseAgreementId(notification.Id),
                ApartmentId = notification.ApartmentId,
                ApartmentName = notification.ApartmentName,
                MonthlyRent = notification.MonthlyRent,
                LeaseTermInMonths = notification.LeaseTermInMonths,
                DateCreated = notification.DateCreated,
                DateStart = notification.DateStart,
                DateEnd = notification.DateEnd,   
                Status = notification.Status
            };
         

            await _unitOfWork.Tenants.AddLeaseAgreementInTenantAsync(new TenantId(notification.TenantId),leaseAgreement);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
