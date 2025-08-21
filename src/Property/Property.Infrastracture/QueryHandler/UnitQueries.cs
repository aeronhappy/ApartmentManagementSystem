using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Property.Application.Queries;
using Property.Application.Response;
using Property.Domain.ValueObjects;
using Property.Infrastracture.Data;

namespace Property.Infrastracture.QueryHandler
{
    public class UnitQueries : IUnitQueries
    {
        private readonly PropertyDbContext _context;
        private readonly IMapper _mapper;

        public UnitQueries(PropertyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        public async Task<List<UnitResponse>> GetListOfUnitResponseAsync()
        {
            return await _context.Units.ProjectTo<UnitResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<UnitResponse?> GetUnitResponseByIdAsync(Guid id)
        {
            var unitResponse = await _context.Units
               .Where(r => r.Id == new UnitId(id))
               .ProjectTo<UnitResponse>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();

            return unitResponse;
        }
    }
}
