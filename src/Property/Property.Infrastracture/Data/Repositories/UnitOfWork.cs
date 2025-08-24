using Property.Domain.Repositories;

namespace Property.Infrastracture.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PropertyDbContext _context;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly IOwnerRepository _ownerRepository;

        public UnitOfWork(PropertyDbContext context, IBuildingRepository buildingRepository, IUnitRepository unitRepository, IOwnerRepository ownerRepository)
        {
            _context = context;
            _buildingRepository = buildingRepository;
            _unitRepository = unitRepository;
            _ownerRepository = ownerRepository;
        }

        public IBuildingRepository Buildings => _buildingRepository;

        public IUnitRepository Units => _unitRepository;

        public IOwnerRepository Owners => _ownerRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
