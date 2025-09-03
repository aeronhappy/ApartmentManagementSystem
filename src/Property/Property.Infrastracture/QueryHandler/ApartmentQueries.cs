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
    public class ApartmentQueries : IApartmentQueries
    {
        private readonly PropertyDbContext _context;
        private readonly IMapper _mapper;

        public ApartmentQueries(PropertyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApartmentResponse?> GetApartmentResponseByIdAsync(Guid id)
        {
            var apartmentResponse = await _context.Apartments
               .Where(r => r.Id == new ApartmentId(id))
               .ProjectTo<ApartmentResponse>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();

            return apartmentResponse;
        }

        public async Task<List<ApartmentResponse>> GetListOfApartmentResponseAsync(string searchText)
        {

            IQueryable<Apartment> query = _context.Apartments.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchText))
            {

                var loweredSearchText = searchText.ToLower();
                query = query.Where(a =>
                                    a.Name.ToLower().Contains(loweredSearchText) ||
                                    a.Number.ToString().ToLower().Contains(loweredSearchText) ||
                                    a.Floor.ToString().ToLower().Contains(loweredSearchText) ||
                                    a.Building.Name.ToLower().Contains(loweredSearchText));
            }


            return await query.OrderByDescending(q => q.Floor).OrderByDescending(q => q.Number)
                              .ProjectTo<ApartmentResponse>(_mapper.ConfigurationProvider).ToListAsync();

        }

        public async Task<List<ApartmentResponse>> GetListOfApartmentResponseByBuildingAsync(string searchText,Guid buildingId)
        {

            IQueryable<Apartment> query = _context.Apartments.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchText))
            {

                var loweredSearchText = searchText.ToLower();
                query = query.Where(a =>
                                    a.Name.ToLower().Contains(loweredSearchText) ||
                                    a.Number.ToString().ToLower().Contains(loweredSearchText) ||
                                    a.Floor.ToString().ToLower().Contains(loweredSearchText));
            }

           
            query = query.Where(apartment => apartment.BuildingId.Value == buildingId);

            return await query.OrderByDescending(q => q.Floor).OrderByDescending(q => q.Number)
                              .ProjectTo<ApartmentResponse>(_mapper.ConfigurationProvider).ToListAsync();

        }
    }
}
