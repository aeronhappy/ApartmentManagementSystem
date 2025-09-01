using AutoMapper;
using Tenancy.Application.Response;
using Tenancy.Domain.Entities;

namespace Tenancy.Infrastracture.MappingProfile
{

    public class TenantMappingProfile : Profile
    {
        public TenantMappingProfile()
        {
            CreateMap<Tenant, TenantResponse>()
                .ForMember(o => o.Id, option => option.MapFrom(o => o.Id.Value));
        }
    }
}
