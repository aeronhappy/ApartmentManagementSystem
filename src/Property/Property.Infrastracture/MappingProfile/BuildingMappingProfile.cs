using AutoMapper;
using Property.Application.Response;
using Property.Domain.Entities;

namespace Property.Infrastracture.MappingProfile
{

    public class BuildingMappingProfile : Profile
    {
        public BuildingMappingProfile()
        {
            CreateMap<Building, BuildingResponse>()
                .ForMember(b => b.Id, option => option.MapFrom(r => r.Id.Value));
            CreateMap<Building, BuildingResponseWithoutApartments>()
                .ForMember(b => b.Id, option => option.MapFrom(r => r.Id.Value));
        }
    }
}
