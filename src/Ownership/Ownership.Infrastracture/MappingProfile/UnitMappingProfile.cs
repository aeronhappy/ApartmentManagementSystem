using AutoMapper;
using Ownership.Application.Response;
using Ownership.Domain.Entities;

namespace Ownership.Infrastracture.MappingProfile
{

    public class UnitMappingProfile : Profile
    {
        public UnitMappingProfile()
        {
            CreateMap<Unit, UnitResponse>()
                .ForMember(u => u.Id, option => option.MapFrom(u => u.Id.Value)); 
            CreateMap<Unit, UnitResponseWithoutBuilding>()
                .ForMember(u => u.Id, option => option.MapFrom(u => u.Id.Value));

        }
    }
}
