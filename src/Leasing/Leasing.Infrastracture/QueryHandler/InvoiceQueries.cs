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
    public class InvoiceQueries : IInvoiceQueries
    {
        private readonly LeasingDbContext _context;
        private readonly IMapper _mapper;

        public InvoiceQueries(LeasingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InvoiceResponse?> GetInvoiceResponseByIdAsync(Guid id)
        {
            var invoiceResponse = await _context.Invoices
                .Where(r => r.Id == new InvoiceId(id))
                .ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return invoiceResponse;
        }

        public async Task<List<InvoiceResponse>> GetListOfInvoiceResponseAsync(string searchText)
        {
            IQueryable<Invoice> query = _context.Invoices.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var loweredSearchText = searchText.ToLower();
                query = query.Where(a =>
                                    a.PaymentReceipt!.ReferenceNumber.ToLower().Contains(loweredSearchText) ||
                                    a.LeaseAgreement.Tenant.Name.ToString().ToLower().Contains(loweredSearchText) ||
                                    a.LeaseAgreement.Apartment.Name.ToString().ToLower().Contains(loweredSearchText) ||
                                    a.LeaseAgreement.Apartment.Number.ToString().ToLower().Contains(loweredSearchText));
            }

            return await query.OrderByDescending(q => q.DatePeriod).ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<InvoiceResponse>> GetListOfInvoiceResponseByTenantAsync(Guid tenantId, string searchText)
        {
            IQueryable<Invoice> query = _context.Invoices.Include(i => i.LeaseAgreement).AsQueryable();

            query = query.Where(invoice => invoice.LeaseAgreement.TenantId == new TenantId(tenantId));


            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var loweredSearchText = searchText.ToLower();
                query = query.Where(a =>
                                    a.PaymentReceipt!.ReferenceNumber.ToLower().Contains(loweredSearchText) ||
                                    a.LeaseAgreement.Tenant.Name.ToString().ToLower().Contains(loweredSearchText) ||
                                    a.LeaseAgreement.Apartment.Name.ToString().ToLower().Contains(loweredSearchText) ||
                                    a.LeaseAgreement.Apartment.Number.ToString().ToLower().Contains(loweredSearchText));
            }


            return await query.OrderByDescending(q => q.DatePeriod).ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<InvoiceResponse>> GetListOfInvoiceResponseByApartmentAsync(Guid apartmentId, string searchText)
        {
            IQueryable<Invoice> query = _context.Invoices.Include(i => i.LeaseAgreement).AsQueryable();

            query = query.Where(invoice => invoice.LeaseAgreement.ApartmentId == new ApartmentId(apartmentId));

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var loweredSearchText = searchText.ToLower();
                query = query.Where(a =>
                                    a.PaymentReceipt!.ReferenceNumber.ToLower().Contains(loweredSearchText) ||
                                    a.LeaseAgreement.Tenant.Name.ToString().ToLower().Contains(loweredSearchText) ||
                                    a.LeaseAgreement.Apartment.Name.ToString().ToLower().Contains(loweredSearchText) ||
                                    a.LeaseAgreement.Apartment.Number.ToString().ToLower().Contains(loweredSearchText));
            }

            return await query.OrderByDescending(q => q.DatePeriod).ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

     
    }
}
