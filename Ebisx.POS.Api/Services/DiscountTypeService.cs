using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Services
{
    public class DiscountTypeService : IDiscountTypeService
    {
        private readonly ApplicationDbContext _dbContext;

        public DiscountTypeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DiscountType>> GetAllDiscountTypesAsync()
        {
            return await _dbContext.DiscountTypes.ToListAsync();
        }

        public async Task<DiscountType?> GetDiscountTypeByIdAsync(int id)
        {
            return await _dbContext.DiscountTypes.FindAsync(id);
        }

        public async Task<DiscountType> CreateDiscountTypeAsync(DiscountType discountType)
        {
            _dbContext.DiscountTypes.Add(discountType);
            await _dbContext.SaveChangesAsync();
            return discountType;
        }

        public async Task<bool> UpdateDiscountTypeAsync(int id, DiscountType updatedDiscountType)
        {
            var discountType = await _dbContext.DiscountTypes.FindAsync(id);
            if (discountType == null) return false;

            discountType.Name = updatedDiscountType.Name;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDiscountTypeAsync(int id)
        {
            var discountType = await _dbContext.DiscountTypes.FindAsync(id);
            if (discountType == null) return false;

            _dbContext.DiscountTypes.Remove(discountType);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
