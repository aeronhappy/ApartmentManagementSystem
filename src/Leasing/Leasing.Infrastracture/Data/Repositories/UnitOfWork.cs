using Leasing.Domain.Repositories;

namespace Leasing.Infrastracture.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeasingDbContext _context;
        private readonly ITenantRepository _tenantRepository; 
        private readonly ILeasingRepository _leasingRepository;
        private readonly IApartmentRepository _apartmentRepository;

        public UnitOfWork(LeasingDbContext context, ITenantRepository tenantRepository, ILeasingRepository leasingRepository,IApartmentRepository apartmentRepository)
        {
            _context = context;
            _tenantRepository = tenantRepository;
            _leasingRepository = leasingRepository;
            _apartmentRepository = apartmentRepository;
        }

        public ITenantRepository Tenants => _tenantRepository;

        public ILeasingRepository Leasings => _leasingRepository;

        public IApartmentRepository Apartments => _apartmentRepository;


        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
