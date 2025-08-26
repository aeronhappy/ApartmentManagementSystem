using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;

namespace Leasing.Infrastracture.Data.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly LeasingDbContext _context;

        public TenantRepository(LeasingDbContext context)
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
            var owner = await _context.Tenants.FindAsync(id);

            if (owner is null)
                return;

            _context.Tenants.Remove(owner);
        }
    }
}
