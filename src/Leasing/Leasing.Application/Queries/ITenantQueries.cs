using Leasing.Application.Response;

namespace Leasing.Application.Queries
{
    public interface ITenantQueries
    {
        Task<List<TenantResponse>> GetListOfTenantResponseAsync();
        Task<TenantResponse?> GetTenantResponseByIdAsync(Guid id);
    }
}
