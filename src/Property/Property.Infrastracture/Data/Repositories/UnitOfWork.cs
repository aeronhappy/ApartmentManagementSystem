using Property.Domain.Repositories;

namespace Property.Infrastracture.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PropertyDbContext _context;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly ILeasingRepository _leasingRepository;

        public UnitOfWork
            (
                 PropertyDbContext context, 
                 IBuildingRepository buildingRepository, 
                 IApartmentRepository apartmentRepository, 
                 IOwnerRepository ownerRepository,
                 ILeasingRepository leasingRepository
            )
        {
            _context = context;
            _buildingRepository = buildingRepository;
            _apartmentRepository = apartmentRepository;
            _ownerRepository = ownerRepository;
            _leasingRepository = leasingRepository;
        }

        public IBuildingRepository Buildings => _buildingRepository;

        public IApartmentRepository Apartments => _apartmentRepository;

        public IOwnerRepository Owners => _ownerRepository;

        public ILeasingRepository Leasings => _leasingRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
