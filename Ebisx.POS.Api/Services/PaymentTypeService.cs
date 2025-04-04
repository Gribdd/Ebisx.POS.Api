using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Services
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentTypeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PaymentType>> GetAllPaymentTypesAsync()
        {
            return await _dbContext.PaymentTypes.ToListAsync();
        }

        public async Task<PaymentType?> GetPaymentTypeByIdAsync(int id)
        {
            return await _dbContext.PaymentTypes.FindAsync(id);
        }

        public async Task<PaymentType> CreatePaymentTypeAsync(PaymentType paymentType)
        {
            _dbContext.PaymentTypes.Add(paymentType);
            await _dbContext.SaveChangesAsync();
            return paymentType;
        }

        public async Task<bool> UpdatePaymentTypeAsync(int id, PaymentType updatedPaymentType)
        {
            var paymentType = await _dbContext.PaymentTypes.FindAsync(id);
            if (paymentType == null) return false;

            paymentType.Name = updatedPaymentType.Name;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePaymentTypeAsync(int id)
        {
            var paymentType = await _dbContext.PaymentTypes.FindAsync(id);
            if (paymentType == null) return false;

            _dbContext.PaymentTypes.Remove(paymentType);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
