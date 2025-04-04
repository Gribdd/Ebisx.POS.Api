using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Services
{
    public class BusinessInfoService : IBusinessInfoService
    {
        private readonly ApplicationDbContext _dbContext;

        public BusinessInfoService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<BusinessInfo>> GetAllBusinessInfoAsync()
        {
            return await _dbContext.BusinessInfos.ToListAsync();
        }

        public async Task<BusinessInfo?> GetBusinessInfoByIdAsync(int id)
        {
            return await _dbContext.BusinessInfos.FindAsync(id);
        }

        public async Task<BusinessInfo> CreateBusinessInfoAsync(BusinessInfo businessInfo)
        {
            _dbContext.BusinessInfos.Add(businessInfo);
            await _dbContext.SaveChangesAsync();
            return businessInfo;
        }

        public async Task<bool> UpdateBusinessInfoAsync(int id, BusinessInfo updatedBusinessInfo)
        {
            var businessInfo = await _dbContext.BusinessInfos.FindAsync(id);
            if (businessInfo == null) return false;

            businessInfo.RegistedName = updatedBusinessInfo.RegistedName;
            businessInfo.Address = updatedBusinessInfo.Address;
            businessInfo.VatTinNumber = updatedBusinessInfo.VatTinNumber;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBusinessInfoAsync(int id)
        {
            var businessInfo = await _dbContext.BusinessInfos.FindAsync(id);
            if (businessInfo == null) return false;

            _dbContext.BusinessInfos.Remove(businessInfo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
