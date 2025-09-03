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
            string ApartmentName,
            double MonthlyRent, 
            int LeaseTermInMonths,
            DateTime DateCreated,DateTime 
            DateStart,
            DateTime DateEnd,
            LeaseStatus Status
        ) : IIntegrationEvent;
   
}
