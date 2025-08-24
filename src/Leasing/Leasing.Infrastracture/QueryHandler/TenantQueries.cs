using AutoMapper;
using AutoMapper.QueryableExtensions;
using Leasing.Application.Queries;
using Leasing.Application.Response;
using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Leasing.Infrastracture.Data;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastracture.QueryHandler
{
    public class TenantQueries : ITenantQueries
    {
        private readonly LeasingDbContext _context;
        private readonly IMapper _mapper;

        public TenantQueries(LeasingDbContext context, IMapper mapper)
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
