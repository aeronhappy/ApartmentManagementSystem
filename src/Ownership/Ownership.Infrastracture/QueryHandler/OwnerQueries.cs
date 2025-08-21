using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Ownership.Application.Queries;
using Ownership.Application.Response;
using Ownership.Domain.Entities;
using Ownership.Domain.ValueObjects;
using Ownership.Infrastracture.Data;
using Property.Application.Response;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Ownership.Infrastracture.QueryHandler
{
    public class OwnerQueries : IOwnerQueries
    {
        private readonly OwnershipDbContext _context;
        private readonly IMapper _mapper;

        public OwnerQueries(OwnershipDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OwnerResponse>> GetListOfOwnerResponseAsync()
        {
            IQueryable<Owner> query = _context.Owners.AsQueryable();

            return await query
                              .ProjectTo<OwnerResponse>(_mapper.ConfigurationProvider).ToListAsync();
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
