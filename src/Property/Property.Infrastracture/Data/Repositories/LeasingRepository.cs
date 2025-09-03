using Microsoft.EntityFrameworkCore;
using Property.Domain.Entities;
using Property.Domain.Repositories;
using Property.Domain.ValueObjects;

namespace Property.Infrastracture.Data.Repositories
{
    public class LeasingRepository : ILeasingRepository
    {
        private readonly PropertyDbContext _context;

        public LeasingRepository(PropertyDbContext context)
        {
            _context = context;
        }

        public async Task<LeaseAgreement?> GetLeaseAgreementByIdAsync(LeaseAgreementId id)
        {
            return await _context.LeaseAgreements
               .Include(b => b.Apartment)
               .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddLeaseAgreementAsync(LeaseAgreement leaseAgreement)
        {
            await _context.LeaseAgreements.AddAsync(leaseAgreement);
        }

        public async Task DeleteLeaseAgreementAsync(LeaseAgreementId id)
        {
            var leaseAgreement = await _context.LeaseAgreements.FindAsync(id);

            if (leaseAgreement is null)
                return;

            _context.LeaseAgreements.Remove(leaseAgreement);
        }
    }
}
