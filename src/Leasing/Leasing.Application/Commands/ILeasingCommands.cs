using ApartmentManagementSystem.SharedKernel.Enum;
using FluentResults;
using Leasing.Application.Response;

namespace Leasing.Application.Commands
{
    public interface ILeasingCommands
    {
        Task<Result<LeaseAgreementResponse>> CreateLeasingAsync(Guid tenantId, Guid unitId, DateTime dateStart, double monthlyRent, int leaseTerm, CancellationToken cancellationToken);
        Task<Result> DeleteLeasingAsync(Guid leaseAgreementId, CancellationToken cancellationToken);
        Task<Result> TerminateLeaseAgreementAsync(Guid leaseAgreementId, CancellationToken cancellationToken);
        Task<Result> RenewLeaseAgreementAsync(Guid leaseAgreementId,int leastTerm, CancellationToken cancellationToken);


    }
}
