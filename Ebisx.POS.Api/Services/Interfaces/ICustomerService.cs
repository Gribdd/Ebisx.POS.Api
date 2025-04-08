using Ebisx.POS.Api.DTOs.Customer;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<CustomerResponseDto>> GetAllCustomersAsync();
    Task<CustomerResponseDto?> GetCustomerByIdAsync(int id);
    Task<CustomerResponseDto> CreateCustomerAsync(CustomerRequestDto customer);
    Task<bool> UpdateCustomerAsync(int id, CustomerRequestDto customer);
    Task<bool> DeleteCustomerAsync(int id);
}
