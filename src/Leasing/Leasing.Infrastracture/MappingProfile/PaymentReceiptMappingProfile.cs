using AutoMapper;
using Leasing.Application.Response;
using Leasing.Domain.Entities;

namespace Leasing.Infrastracture.MappingProfile
{

    public class PaymentReceiptMappingProfile : Profile
    {
        public PaymentReceiptMappingProfile()
        {
            CreateMap<PaymentReceipt, PaymentReceiptResponse>()
                .ForMember(o => o.Id, option => option.MapFrom(o => o.Id.Value));
            CreateMap<PaymentReceipt, PaymentReceiptResponseWithoutInvoice>()
               .ForMember(o => o.Id, option => option.MapFrom(o => o.Id.Value));
        }
    }
}
