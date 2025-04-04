using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Services
{
    public class NonCashPaymentMethodService : INonCashPaymentMethodService
    {
        private readonly ApplicationDbContext _dbContext;

        public NonCashPaymentMethodService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<NonCashPaymentMethod>> GetAllNonCashPaymentMethodsAsync()
        {
            return await _dbContext.NonCashPaymentMethods.ToListAsync();
        }

        public async Task<NonCashPaymentMethod?> GetNonCashPaymentMethodByIdAsync(int id)
        {
            return await _dbContext.NonCashPaymentMethods.FindAsync(id);
        }

        public async Task<NonCashPaymentMethod> CreateNonCashPaymentMethodAsync(NonCashPaymentMethod nonCashPaymentMethod)
        {
            _dbContext.NonCashPaymentMethods.Add(nonCashPaymentMethod);
            await _dbContext.SaveChangesAsync();
            return nonCashPaymentMethod;
        }

        public async Task<bool> UpdateNonCashPaymentMethodAsync(int id, NonCashPaymentMethod updatedNonCashPaymentMethod)
        {
            var nonCashPaymentMethod = await _dbContext.NonCashPaymentMethods.FindAsync(id);
            if (nonCashPaymentMethod == null) return false;

            nonCashPaymentMethod.Provider = updatedNonCashPaymentMethod.Provider;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteNonCashPaymentMethodAsync(int id)
        {
            var nonCashPaymentMethod = await _dbContext.NonCashPaymentMethods.FindAsync(id);
            if (nonCashPaymentMethod == null) return false;

            _dbContext.NonCashPaymentMethods.Remove(nonCashPaymentMethod);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
