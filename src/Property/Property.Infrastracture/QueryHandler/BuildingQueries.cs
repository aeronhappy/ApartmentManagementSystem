using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Property.Application.Queries;
using Property.Application.Response;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;
using Property.Infrastracture.Data;

namespace Property.Infrastracture.QueryHandler
{
    public class BuildingQueries : IBuildingQueries
    {
        private readonly PropertyDbContext _context;
        private readonly IMapper _mapper;

        public BuildingQueries(PropertyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BuildingResponse?> GetBuildingResponseByIdAsync(Guid id)
        {
            var buildingResponse = await _context.Buildings
                .Where(r => r.Id == new BuildingId(id))
                .ProjectTo<BuildingResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return buildingResponse;
        }

        public async Task<List<BuildingResponse>> GetListOfBuildingResponseAsync()
        {
            IQueryable<Building> query = _context.Buildings.AsQueryable();

            return await query
                              .ProjectTo<BuildingResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }


    }
}
