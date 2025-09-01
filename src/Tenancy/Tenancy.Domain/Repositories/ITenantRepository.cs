using Tenancy.Domain.Entities;
using Tenancy.Domain.ValueObjects;


namespace Tenancy.Domain.Repositories
{
    public interface ITenantRepository
    {
        Task<Tenant?> GetTenantByIdAsync(TenantId id);
        Task AddTenantAsync(Tenant tenant);
        Task AddLeaseAgreementInTenantAsync(TenantId id , LeaseAgreement leaseAgreement);
        Task DeleteTenantAsync(TenantId id);
    }
}
