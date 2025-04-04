using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Services
{
    public class MachineInfoService : IMachineInfoService
    {
        private readonly ApplicationDbContext _dbContext;

        public MachineInfoService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MachineInfo>> GetAllMachineInfoAsync()
        {
            return await _dbContext.MachineInfos.ToListAsync();
        }

        public async Task<MachineInfo?> GetMachineInfoByIdAsync(int id)
        {
            return await _dbContext.MachineInfos.FindAsync(id);
        }

        public async Task<MachineInfo> CreateMachineInfoAsync(MachineInfo machineInfo)
        {
            _dbContext.MachineInfos.Add(machineInfo);
            await _dbContext.SaveChangesAsync();
            return machineInfo;
        }

        public async Task<bool> UpdateMachineInfoAsync(int id, MachineInfo updatedMachineInfo)
        {
            var machineInfo = await _dbContext.MachineInfos.FindAsync(id);
            if (machineInfo == null) return false;

            machineInfo.PosSerialNumber = updatedMachineInfo.PosSerialNumber;
            machineInfo.MinNumber = updatedMachineInfo.MinNumber;
            machineInfo.AccreditationNumber = updatedMachineInfo.AccreditationNumber;
            machineInfo.PtuNumber = updatedMachineInfo.PtuNumber;
            machineInfo.DateIssued = updatedMachineInfo.DateIssued;
            machineInfo.ValidUntil = updatedMachineInfo.ValidUntil;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMachineInfoAsync(int id)
        {
            var machineInfo = await _dbContext.MachineInfos.FindAsync(id);
            if (machineInfo == null) return false;

            _dbContext.MachineInfos.Remove(machineInfo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
