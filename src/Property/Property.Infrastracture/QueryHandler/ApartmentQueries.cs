using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Property.Application.Queries;
using Property.Application.Response;
using Property.Domain.ValueObjects;
using Property.Infrastracture.Data;

namespace Property.Infrastracture.QueryHandler
{
    public class ApartmentQueries : IApartmentQueries
    {
        private readonly PropertyDbContext _context;
        private readonly IMapper _mapper;

        public ApartmentQueries(PropertyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<ApartmentResponse>> GetListOfApartmentResponseAsync()
        {
            return await _context.Apartments.ProjectTo<ApartmentResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<ApartmentResponse?> GetApartmentResponseByIdAsync(Guid id)
        {
            var apartmentResponse = await _context.Apartments
               .Where(r => r.Id == new ApartmentId(id))
               .ProjectTo<ApartmentResponse>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();

            return apartmentResponse;
        }
    }
}
