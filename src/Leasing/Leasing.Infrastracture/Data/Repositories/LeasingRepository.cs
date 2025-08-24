using ApartmentManagementSystem.SharedKernel.Entitites;
using ApartmentManagementSystem.SharedKernel.ValueObject;
using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;

namespace Leasing.Infrastracture.Data.Repositories
{
    public class LeasingRepository : ILeasingRepository
    {
        private readonly LeasingDbContext _context;

        public LeasingRepository(LeasingDbContext context)
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
            var unit = await _context.LeaseAgreements.FindAsync(id);

            if (unit is null)
                return;

            _context.LeaseAgreements.Remove(unit);
        }
    }
}
