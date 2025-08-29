using AutoMapper;
using AutoMapper.QueryableExtensions;
using Leasing.Application.Queries;
using Leasing.Application.Response;
using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Leasing.Infrastracture.Data;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastracture.QueryHandler
{
    public class PaymentReceiptQueries : IPaymentReceiptQueries
    {
        private readonly LeasingDbContext _context;
        private readonly IMapper _mapper;

        public PaymentReceiptQueries(LeasingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PaymentReceiptResponse>> GetListOfPaymentReceiptResponseAsync()
        {
            IQueryable<PaymentReceipt> query = _context.PaymentReceipts.AsQueryable();

            return await query.ProjectTo<PaymentReceiptResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<PaymentReceiptResponse>> GetListOfPaymentReceiptResponseByTenantAsync(Guid tenantId)
        {
            IQueryable<PaymentReceipt> query = _context.PaymentReceipts.AsQueryable();

            query = query.Where(paymentReceipt => paymentReceipt.Invoice.LeaseAgreement.TenantId.Value == tenantId);

            return await query.ProjectTo<PaymentReceiptResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public  async Task<List<PaymentReceiptResponse>> GetListOfPaymentReceiptResponseByApartmentAsync(Guid apartmentId)
        {
            IQueryable<PaymentReceipt> query = _context.PaymentReceipts.AsQueryable();

            query = query.Where(paymentReceipt => paymentReceipt.Invoice.LeaseAgreement.ApartmentId.Value == apartmentId);

            return await query.ProjectTo<PaymentReceiptResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<PaymentReceiptResponse?> GetPaymentReceiptResponseByIdAsync(Guid id)
        {
            var paymentReceiptResponse = await _context.PaymentReceipts
                 .Where(r => r.Id == new PaymentReceiptId(id))
                 .ProjectTo<PaymentReceiptResponse>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

            return paymentReceiptResponse;
        }

    }
}
