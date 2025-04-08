using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Ebisx.POS.Api.DTOs.Customer;

namespace Ebisx.POS.Api.Services;

/// <summary>
/// Service for managing customer information in the POS system.
/// </summary>
public class CustomerService : ICustomerService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerService"/> class.
    /// </summary>
    /// <param name="dbContext">The database context for accessing customer data.</param>
    /// <param name="mapper">The mapper for converting between entities and DTOs.</param>
    public CustomerService(
        ApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all customers from the database.
    /// </summary>
    /// <returns>A collection of <see cref="CustomerResponseDto"/> representing all customers.</returns>
    public async Task<IEnumerable<CustomerResponseDto>> GetAllCustomersAsync()
    {
        try
        {
            var customers = await _dbContext.Customers.ToListAsync();
            var customerDtos = _mapper.Map<IEnumerable<CustomerResponseDto>>(customers);
            return customerDtos;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Retrieves specific customer information by its ID.
    /// </summary>
    /// <param name="id">The ID of the customer to retrieve.</param>
    /// <returns>A <see cref="CustomerResponseDto"/> representing the customer, or null if not found.</returns>
    public async Task<CustomerResponseDto?> GetCustomerByIdAsync(int id)
    {
        try
        {
            var customer = await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null) return null;
            var customerDto = _mapper.Map<CustomerResponseDto>(customer);
            return customerDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Creates a new customer in the database.
    /// </summary>
    /// <param name="customerDto">The <see cref="CustomerRequestDto"/> containing customer details.</param>
    /// <returns>The created <see cref="CustomerResponseDto"/>.</returns>
    public async Task<CustomerResponseDto> CreateCustomerAsync(CustomerRequestDto customerDto)
    {
        try
        {
            var customerEntity = _mapper.Map<Customer>(customerDto);
            _dbContext.Customers.Add(customerEntity);
            await _dbContext.SaveChangesAsync();

            var createdCustomerDto = _mapper.Map<CustomerResponseDto>(customerEntity);
            return createdCustomerDto;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Updates existing customer information in the database.
    /// </summary>
    /// <param name="id">The ID of the customer to update.</param>
    /// <param name="updatedCustomerDto">The updated customer details.</param>
    /// <returns>True if the update was successful, false if the customer was not found.</returns>
    public async Task<bool> UpdateCustomerAsync(int id, CustomerRequestDto updatedCustomerDto)
    {
        try
        {
            var existingCustomer = await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.Id == id);

            if (existingCustomer == null)
                return false;

            var existingEntry = _dbContext.Entry(existingCustomer);
            existingEntry.CurrentValues.SetValues(updatedCustomerDto);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Deletes a customer from the database.
    /// </summary>
    /// <param name="id">The ID of the customer to delete.</param>
    /// <returns>True if the deletion was successful, false if the customer was not found.</returns>
    public async Task<bool> DeleteCustomerAsync(int id)
    {
        try
        {
            var customer = await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null) return false;

            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }
}
