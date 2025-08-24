using ApartmentManagementSystem.SharedKernel.Enum;
using FluentResults;
using Leasing.Application.Response;

namespace Leasing.Application.Commands
{
    public interface ILeasingCommands
    {
        Task<Result<LeaseAgreementResponse>> CreateLeasingAsync(Guid tenantId, Guid unitId, DateTime dateStart,double monthlyRent,LeaseTerm leaseTerm, CancellationToken cancellationToken);
        Task<Result> DeleteLeasingAsync(Guid leaseAgreementId, CancellationToken cancellationToken);
        }
}
