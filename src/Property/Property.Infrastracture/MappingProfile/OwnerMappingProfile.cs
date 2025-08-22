using AutoMapper;
using Property.Application.Response;
using Property.Domain.Entities;

namespace Property.Infrastracture.MappingProfile
{

    public class OwnerMappingProfile : Profile
    {
        public OwnerMappingProfile()
        {
            CreateMap<Owner, OwnerResponse>()
                .ForMember(o => o.Id, option => option.MapFrom(o => o.Id.Value));
        }
    }
}
