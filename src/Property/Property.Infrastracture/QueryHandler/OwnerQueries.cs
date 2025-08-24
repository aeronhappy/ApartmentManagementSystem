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
    public class OwnerQueries : IOwnerQueries
    {
        private readonly PropertyDbContext _context;
        private readonly IMapper _mapper;

        public OwnerQueries(PropertyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OwnerResponse>> GetListOfOwnerResponseAsync()
        {
            IQueryable<Owner> query = _context.Owners.AsQueryable();

            return await query.ProjectTo<OwnerResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<OwnerResponse?> GetOwnerResponseByIdAsync(Guid id)
        {
            var ownerResponse = await _context.Owners
                 .Where(r => r.Id == new OwnerId(id))
                 .ProjectTo<OwnerResponse>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

            return ownerResponse;
        }
    }
}
