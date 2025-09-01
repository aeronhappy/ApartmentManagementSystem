using Tenancy.Domain.Repositories;

namespace Tenancy.Infrastracture.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TenancyDbContext _context;
        private readonly ITenantRepository _tenantRepository; 
        private readonly ILeasingRepository _leasingRepository;

        public UnitOfWork
            (TenancyDbContext context, 
            ITenantRepository tenantRepository, 
            ILeasingRepository leasingRepository)
        {
            _context = context;
            _tenantRepository = tenantRepository;
            _leasingRepository = leasingRepository;
        }

        public ITenantRepository Tenants => _tenantRepository;
        public ILeasingRepository Leasings => _leasingRepository;


        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
