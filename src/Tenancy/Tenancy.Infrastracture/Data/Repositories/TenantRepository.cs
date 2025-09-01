using Tenancy.Domain.Entities;
using Tenancy.Domain.Repositories;
using Tenancy.Domain.ValueObjects;

namespace Tenancy.Infrastracture.Data.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly TenancyDbContext _context;

        public TenantRepository(TenancyDbContext context)
        {
            _context = context;
        }

        public async Task<Tenant?> GetTenantByIdAsync(TenantId id)
        {
            return await _context.Tenants.FindAsync(id);
        }

        public  async Task AddTenantAsync(Tenant tenant)
        {
            await _context.Tenants.AddAsync(tenant);
        }

        public async Task DeleteTenantAsync(TenantId id)
        {
            var tenant = await _context.Tenants.FindAsync(id);

            if (tenant is null)
                return;

            _context.Tenants.Remove(tenant);
        }

        public async Task AddLeaseAgreementInTenantAsync(TenantId id, LeaseAgreement leaseAgreement)
        {
            var tenant = await _context.Tenants.FindAsync(id);

            if(tenant is null)
                return; 

            tenant.LeaseAgreements.Add(leaseAgreement);
        }
    }
}
