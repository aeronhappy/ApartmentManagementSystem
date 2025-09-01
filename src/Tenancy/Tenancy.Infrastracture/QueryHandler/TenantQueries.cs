using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Tenancy.Application.Queries;
using Tenancy.Application.Response;
using Tenancy.Domain.Entities;
using Tenancy.Domain.ValueObjects;
using Tenancy.Infrastracture.Data;

namespace Tenancy.Infrastracture.QueryHandler
{
    public class TenantQueries : ITenantQueries
    {
        private readonly TenancyDbContext _context;
        private readonly IMapper _mapper;

        public TenantQueries(TenancyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TenantResponse>> GetListOfTenantResponseAsync()
        {
            IQueryable<Tenant> query = _context.Tenants.AsQueryable();

            return await query.ProjectTo<TenantResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

       
        public async Task<TenantResponse?> GetTenantResponseByIdAsync(Guid id)
        {
            var tenantResponse = await _context.Tenants
                 .Where(r => r.Id == new TenantId(id))
                 .ProjectTo<TenantResponse>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

            return tenantResponse;
        }
    }
}
