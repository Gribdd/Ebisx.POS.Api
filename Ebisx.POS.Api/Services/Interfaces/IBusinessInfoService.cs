using Ebisx.POS.Api.DTOs.BusinessInfo;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface IBusinessInfoService
{
    Task<IEnumerable<BusinessInfoResponseDto>> GetAllBusinessInfoAsync();
    Task<BusinessInfoResponseDto?> GetBusinessInfoByIdAsync(int id);
    Task<BusinessInfoResponseDto> CreateBusinessInfoAsync(BusinessInfoRequestDto businessInfo);
    Task<bool> UpdateBusinessInfoAsync(int id, BusinessInfoRequestDto businessInfo);
    Task<bool> DeleteBusinessInfoAsync(int id);
}
