using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OTF_System.Models;
using OTF_System.Data;
using OTF_System.Data;
using OTF_System.Models;

namespace Sachintha.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly dbcontext _context;

        public PaymentService(dbcontext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            return await _context.Payment.ToListAsync();
        }

        public async Task<Payment> GetPaymentByIdAsync(string id)
        {
            return await _context.Payment.FindAsync(id);
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            _context.Payment.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            _context.Payment.Update(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeletePaymentAsync(string id)
        {
            var payment = await _context.Payment.FindAsync(id);
            if (payment == null) return false;

            _context.Payment.Remove(payment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
