using AutoMapper;
using Property.Application.Response;
using Property.Domain.Entities;

namespace Property.Infrastracture.MappingProfile
{

    public class ApartmentMappingProfile : Profile
    {
        public ApartmentMappingProfile()
        {
            CreateMap<Apartment, ApartmentResponse>()
                .ForMember(u => u.Id, option => option.MapFrom(u => u.Id.Value));
            CreateMap<Apartment, ApartmentResponseWithoutBuilding>()
               .ForMember(u => u.Id, option => option.MapFrom(u => u.Id.Value));

        }
    }
}
