using Ebisx.POS.Api.DTOs.MachineInfo;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface IMachineInfoService
{
    Task<IEnumerable<MachineInfoResponseDto>> GetAllMachineInfoAsync();
    Task<MachineInfoResponseDto?> GetMachineInfoByIdAsync(int id);
    Task<MachineInfoResponseDto> CreateMachineInfoAsync(MachineInfoRequestDto machineInfo);
    Task<bool> UpdateMachineInfoAsync(int id, MachineInfoRequestDto machineInfo);
    Task<bool> DeleteMachineInfoAsync(int id);
}
