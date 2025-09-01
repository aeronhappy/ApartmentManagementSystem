using AutoMapper;
using Ownership.Application.Response;
using Ownership.Domain.Entities;

namespace Ownership.Infrastracture.MappingProfile
{

    public class ApartmentMappingProfile : Profile
    {
        public ApartmentMappingProfile()
        {
            CreateMap<Apartment, ApartmentResponse>()
                .ForMember(u => u.Id, option => option.MapFrom(u => u.Id.Value));

        }
    }
}
