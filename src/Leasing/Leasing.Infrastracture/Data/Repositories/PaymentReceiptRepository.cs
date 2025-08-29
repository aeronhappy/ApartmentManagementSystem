using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Property.Domain.Entities;

namespace Leasing.Infrastracture.Data.Repositories
{
    public class PaymentReceiptRepository : IPaymentReceiptRepository
    {
        private readonly LeasingDbContext _context;

        public PaymentReceiptRepository(LeasingDbContext context)
        {
            _context = context;
        }

        public async Task AddPaymentReceiptAsync(PaymentReceipt paymentReceipt)
        {
            await _context.PaymentReceipts.AddAsync(paymentReceipt);
        }


        public async Task<PaymentReceipt?> GetPaymentReceiptByIdAsync(PaymentReceiptId id)
        {
            return await _context.PaymentReceipts
              .Include(i => i.Invoice)
              .FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
