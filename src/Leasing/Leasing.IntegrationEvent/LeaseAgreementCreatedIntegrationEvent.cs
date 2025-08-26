using ApartmentManagementSystem.SharedKernel;
using Leasing.Domain.Entities;

namespace Leasing.IntegrationEvent
{
    public record LeaseAgreementCreatedIntegrationEvent(LeaseAgreement LeaseAgreement) : IIntegrationEvent;
   
}
