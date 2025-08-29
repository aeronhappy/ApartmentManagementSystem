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

        public async Task<List<InvoiceResponse>> GetListOfInvoiceResponseAsync()
        {
            IQueryable<Invoice> query = _context.Invoices.AsQueryable();

            return await query.ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<InvoiceResponse>> GetListOfInvoiceResponseByTenantAsync(Guid tenantId)
        {
            IQueryable<Invoice> query = _context.Invoices.AsQueryable();
            query = query.Where(invoice => invoice.LeaseAgreement.TenantId.Value == tenantId);

            return await query.ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<InvoiceResponse>> GetListOfInvoiceResponseByApartmentAsync(Guid apartmentId)
        {
            IQueryable<Invoice> query = _context.Invoices.AsQueryable();
            query = query.Where(invoice => invoice.LeaseAgreement.ApartmentId.Value == apartmentId);

            return await query.ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

     
    }
}
