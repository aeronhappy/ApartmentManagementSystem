using Property.Domain.Repositories;

namespace Property.Infrastracture.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PropertyDbContext _context;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IUnitRepository _unitRepository;

        public UnitOfWork(PropertyDbContext context,IBuildingRepository buildingRepository,IUnitRepository unitRepository)
        {
            _context = context;
            _buildingRepository = buildingRepository;
            _unitRepository = unitRepository;
        }

        public IBuildingRepository Buildings => _buildingRepository;

        public IUnitRepository Units => _unitRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
