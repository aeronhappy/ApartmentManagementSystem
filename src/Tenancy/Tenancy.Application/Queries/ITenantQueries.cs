using Tenancy.Application.Response;

namespace Tenancy.Application.Queries
{
    public interface ITenantQueries
    {
        Task<List<TenantResponse>> GetListOfTenantResponseAsync();
        Task<TenantResponse?> GetTenantResponseByIdAsync(Guid id);
    }
}
