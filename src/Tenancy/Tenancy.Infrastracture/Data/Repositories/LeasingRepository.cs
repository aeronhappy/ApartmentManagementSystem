using Tenancy.Domain.Entities;
using Tenancy.Domain.Repositories;
using Tenancy.Domain.ValueObjects;

namespace Tenancy.Infrastracture.Data.Repositories
{
    public class LeasingRepository : ILeasingRepository
    {
        private readonly TenancyDbContext _context;

        public LeasingRepository(TenancyDbContext context)
        {
            _context = context;
        }

        public async Task<LeaseAgreement?> GetLeasingByIdAsync(LeaseAgreementId id)
        {
            return await _context.LeaseAgreements.FindAsync(id);
        }

        public async Task AddLeasingAsync(LeaseAgreement unit)
        {
            await _context.LeaseAgreements.AddAsync(unit);
        }

        public async Task DeleteLeasingAsync(LeaseAgreementId id)
        {
            var leaseAgreement = await _context.LeaseAgreements.FindAsync(id);

            if (leaseAgreement is null)
                return;

            _context.LeaseAgreements.Remove(leaseAgreement);
        }
    }
}
