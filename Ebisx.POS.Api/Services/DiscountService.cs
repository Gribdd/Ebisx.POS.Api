using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly ApplicationDbContext _dbContext;

        public DiscountService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Discount>> GetAllDiscountsAsync()
        {
            return await _dbContext.Discounts.Include(d => d.DiscountType).ToListAsync();
        }

        public async Task<Discount?> GetDiscountByIdAsync(int id)
        {
            return await _dbContext.Discounts.Include(d => d.DiscountType).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Discount> CreateDiscountAsync(Discount discount)
        {
            _dbContext.Discounts.Add(discount);
            await _dbContext.SaveChangesAsync();
            return discount;
        }

        public async Task<bool> UpdateDiscountAsync(int id, Discount updatedDiscount)
        {
            var discount = await _dbContext.Discounts.FindAsync(id);
            if (discount == null) return false;

            discount.Value = updatedDiscount.Value;
            discount.IsPercentage = updatedDiscount.IsPercentage;
            discount.DiscountTypeId = updatedDiscount.DiscountTypeId;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDiscountAsync(int id)
        {
            var discount = await _dbContext.Discounts.FindAsync(id);
            if (discount == null) return false;

            _dbContext.Discounts.Remove(discount);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
