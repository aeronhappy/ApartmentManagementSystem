using AutoMapper;
using Property.Application.Response;
using Property.Domain.Entities;

namespace Property.Infrastracture.MappingProfile
{

    public class LeaseAgreementMappingProfile : Profile
    {
        public LeaseAgreementMappingProfile()
        {
            CreateMap<LeaseAgreement, LeaseAgreementResponseWihoutApartment>()
                .ForMember(o => o.Id, option => option.MapFrom(o => o.Id.Value));
        }
    }
}
