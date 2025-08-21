using AutoMapper;
using Ownership.Application.Response;
using Ownership.Domain.Entities;

namespace Ownership.Infrastracture.MappingProfile
{

    public class BuildingMappingProfile : Profile
    {
        public BuildingMappingProfile()
        {
            CreateMap<Building, BuildingResponse>()
                .ForMember(b => b.Id, option => option.MapFrom(r => r.Id.Value));
            CreateMap<Building, BuildingResponseWithoutUnits>()
                .ForMember(b => b.Id, option => option.MapFrom(r => r.Id.Value));
        }
    }
}
