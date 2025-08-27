using FluentResults;
using Leasing.Application.Response;

namespace Leasing.Application.Commands
{
    public interface ITenantCommands
    {

        Task<Result<TenantResponse>> AddTenantAsync(Guid id,string email, string name, string address,int gender, string contactNumber, CancellationToken cancellationToken);
        Task<Result> DeleteTenantAsync(Guid tenantId, CancellationToken cancellationToken);
        Task<Result> UpdateTenantAsync(Guid tenantId, string name, string address, string contactNumber, CancellationToken cancellationToken);

    }
}
