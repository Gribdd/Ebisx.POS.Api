using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _dbContext.Payments.Include(p => p.PaymentType).ToListAsync();
        }

        public async Task<Payment?> GetPaymentByIdAsync(int id)
        {
            return await _dbContext.Payments.Include(p => p.PaymentType).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            _dbContext.Payments.Add(payment);
            await _dbContext.SaveChangesAsync();
            return payment;
        }

        public async Task<bool> UpdatePaymentAsync(int id, Payment updatedPayment)
        {
            var payment = await _dbContext.Payments.FindAsync(id);
            if (payment == null) return false;

            payment.AmountPaid = updatedPayment.AmountPaid;
            payment.PaymentTypeId = updatedPayment.PaymentTypeId;
            payment.OrderId = updatedPayment.OrderId;
            payment.NonCashPaymentMethodID = updatedPayment.NonCashPaymentMethodID;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            var payment = await _dbContext.Payments.FindAsync(id);
            if (payment == null) return false;

            _dbContext.Payments.Remove(payment);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
