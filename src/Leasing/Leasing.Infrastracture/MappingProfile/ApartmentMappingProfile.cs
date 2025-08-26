using AutoMapper;
using Leasing.Application.Response;
using Leasing.Domain.Entities;

namespace Leasing.Infrastracture.MappingProfile
{

    public class ApartmentMappingProfile : Profile
    {
        public ApartmentMappingProfile()
        {
            CreateMap<Apartment, ApartmentResponse>()
                .ForMember(o => o.Id, option => option.MapFrom(o => o.Id.Value));
        }
    }
}
