using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastracture.Data.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly LeasingDbContext _context;

        public InvoiceRepository(LeasingDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice?> GetInvoiceByIdAsync(InvoiceId id)
        {
            return await _context.Invoices
               .Include(i => i.LeaseAgreement)
               .FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
