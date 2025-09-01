using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;
using MediatR;
using Tenancy.IntegrationEvent;

namespace Leasing.Application.EventHandler.Integration
{


    public class TenantCreatedIntegrationEventHandler : INotificationHandler<TenantCreatedIntegrationEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TenantCreatedIntegrationEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(TenantCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {

            Tenant tenant = new()
            {
                Id = new TenantId(notification.TenantId),
                Email = notification.Email,
                Name = notification.Name
            };

            await _unitOfWork.Tenants.AddTenantAsync(tenant);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
