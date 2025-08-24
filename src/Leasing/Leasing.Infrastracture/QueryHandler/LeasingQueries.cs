using AutoMapper;
using AutoMapper.QueryableExtensions;
using Leasing.Application.Queries;
using Leasing.Application.Response;
using Leasing.Domain.ValueObjects;
using Leasing.Infrastracture.Data;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastracture.QueryHandler
{
    public class LeasingQueries : ILeasingQueries
    {
        private readonly LeasingDbContext _context;
        private readonly IMapper _mapper;

        public LeasingQueries(LeasingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LeaseAgreementResponse?> GetLeaseAgreementResponseByIdAsync(Guid id)
        {
            var leaseAgreementResponse = await _context.LeaseAgreements
                 .Where(r => r.Id == new LeaseAgreementId(id))
                 .ProjectTo<LeaseAgreementResponse>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

            return leaseAgreementResponse;
        }

        public async Task<List<LeaseAgreementResponse>> GetListOfLeaseAgreementResponseAsync()
        {
            return await _context.LeaseAgreements.ProjectTo<LeaseAgreementResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

       

    
    }
}
