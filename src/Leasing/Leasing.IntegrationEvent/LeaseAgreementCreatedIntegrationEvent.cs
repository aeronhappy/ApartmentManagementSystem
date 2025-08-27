using ApartmentManagementSystem.SharedKernel;
using ApartmentManagementSystem.SharedKernel.Enum;

namespace Leasing.IntegrationEvent
{
    public record LeaseAgreementCreatedIntegrationEvent
        (
            Guid Id, 
            Guid TenantId,
            string TenantName,
            Guid ApartmentId,
            double MonthlyRent, 
            LeaseTerm LeaseTermInMonths,
            DateTime DateCreated,DateTime 
            DateStart,
            DateTime DateEnd,
            LeaseStatus Status
        ) : IIntegrationEvent;
   
}
