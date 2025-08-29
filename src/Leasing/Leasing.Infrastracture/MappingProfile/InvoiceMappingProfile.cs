using AutoMapper;
using Leasing.Application.Response;
using Leasing.Domain.Entities;

namespace Leasing.Infrastracture.MappingProfile
{

    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceResponse>()
                .ForMember(o => o.Id, option => option.MapFrom(o => o.Id.Value));
            CreateMap<Invoice, InvoiceResponseWithoutPaymentReceipt>()
              .ForMember(o => o.Id, option => option.MapFrom(o => o.Id.Value));
        }
    }
}
