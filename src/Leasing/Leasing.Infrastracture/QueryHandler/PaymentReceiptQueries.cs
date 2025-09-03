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

        public async Task<List<PaymentReceiptResponse>> GetListOfPaymentReceiptResponseAsync(string searchText)
        {
            IQueryable<PaymentReceipt> query = _context.PaymentReceipts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var loweredSearchText = searchText.ToLower();
                query = query.Where(a =>
                                    a.PaymentDate.ToString().ToLower().Contains(loweredSearchText) ||
                                    a.PaymentMethod.ToString().ToLower().Contains(loweredSearchText) ||
                                    a.ReferenceNumber.ToLower().Contains(loweredSearchText) ||
                                    a.Invoice.Status.ToString().ToLower().Contains(loweredSearchText));
            }

            return await query.OrderByDescending(q => q.PaymentDate).ProjectTo<PaymentReceiptResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<PaymentReceiptResponse>> GetListOfPaymentReceiptResponseByTenantAsync(Guid tenantId, string searchText)
        {
            IQueryable<PaymentReceipt> query = _context.PaymentReceipts.Include(pr => pr.Invoice).ThenInclude(i => i.LeaseAgreement).AsQueryable();

            query = query.Where(paymentReceipt => paymentReceipt.Invoice.LeaseAgreement.TenantId == new TenantId(tenantId));

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var loweredSearchText = searchText.ToLower();
                query = query.Where(a =>
                                    a.PaymentDate.ToString().ToLower().Contains(loweredSearchText) ||
                                    a.PaymentMethod.ToString().ToLower().Contains(loweredSearchText) ||
                                    a.ReferenceNumber.ToLower().Contains(loweredSearchText) ||
                                    a.Invoice.Status.ToString().ToLower().Contains(loweredSearchText));
            }

            return await query.OrderByDescending(q=>q.PaymentDate).ProjectTo<PaymentReceiptResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public  async Task<List<PaymentReceiptResponse>> GetListOfPaymentReceiptResponseByApartmentAsync(Guid apartmentId, string searchText)
        {
            IQueryable<PaymentReceipt> query = _context.PaymentReceipts.Include(pr=>pr.Invoice).ThenInclude(i => i.LeaseAgreement).AsQueryable();

            query = query.Where(paymentReceipt => paymentReceipt.Invoice.LeaseAgreement.ApartmentId == new ApartmentId(apartmentId));

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var loweredSearchText = searchText.ToLower();
                query = query.Where(a =>
                                    a.PaymentDate.ToString().ToLower().Contains(loweredSearchText) ||
                                    a.PaymentMethod.ToString().ToLower().Contains(loweredSearchText) ||
                                    a.ReferenceNumber.ToLower().Contains(loweredSearchText) ||
                                    a.Invoice.Status.ToString().ToLower().Contains(loweredSearchText));
            }

            return await query.OrderByDescending(q => q.PaymentDate).ProjectTo<PaymentReceiptResponse>(_mapper.ConfigurationProvider).ToListAsync();
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
