using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;


namespace Leasing.Domain.Repositories
{
    public interface ITenantRepository
    {
        Task<Tenant?> GetTenantByIdAsync(TenantId id);
        Task AddTenantAsync(Tenant tenant);
        Task DeleteTenantAsync(TenantId id);
    }
}
