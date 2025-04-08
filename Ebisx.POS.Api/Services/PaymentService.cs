using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Ebisx.POS.Api.DTOs.Payment;

namespace Ebisx.POS.Api.Services
{
    /// <summary>
    /// Service for managing payments in the POS system.
    /// </summary>
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context for accessing payment data.</param>
        /// <param name="mapper">The mapper for converting between entities and DTOs.</param>
        public PaymentService(
            ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all payments from the database.
        /// </summary>
        /// <returns>A collection of <see cref="PaymentResponseDto"/> representing all payments.</returns>
        public async Task<IEnumerable<PaymentResponseDto>> GetAllPaymentsAsync()
        {
            try
            {
                var payments = await _dbContext.Payments
                    .Include(p => p.PaymentType)
                    .Include(p => p.NonCashPaymentMethod)
                    .ToListAsync();

                var paymentDtos = _mapper.Map<IEnumerable<PaymentResponseDto>>(payments);
                return paymentDtos;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieves specific payment information by its ID.
        /// </summary>
        /// <param name="id">The ID of the payment to retrieve.</param>
        /// <returns>A <see cref="PaymentResponseDto"/> representing the payment, or null if not found.</returns>
        public async Task<PaymentResponseDto?> GetPaymentByIdAsync(int id)
        {
            try
            {
                var payment = await _dbContext.Payments
                    .Include(p => p.PaymentType)
                    .Include(p => p.NonCashPaymentMethod)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (payment == null) return null;
                var paymentDto = _mapper.Map<PaymentResponseDto>(payment);
                return paymentDto;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Creates a new payment in the database.
        /// </summary>
        /// <param name="paymentDto">The <see cref="PaymentRequestDto"/> containing payment details.</param>
        /// <returns>The created <see cref="PaymentResponseDto"/>.</returns>
        public async Task<PaymentResponseDto> CreatePaymentAsync(PaymentRequestDto paymentDto)
        {
            try
            {
                var paymentEntity = _mapper.Map<Payment>(paymentDto);
                _dbContext.Payments.Add(paymentEntity);
                await _dbContext.SaveChangesAsync();

                var createdPaymentDto = _mapper.Map<PaymentResponseDto>(paymentEntity);
                return createdPaymentDto;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Updates existing payment information in the database.
        /// </summary>
        /// <param name="id">The ID of the payment to update.</param>
        /// <param name="updatedPaymentDto">The updated payment details.</param>
        /// <returns>True if the update was successful, false if the payment was not found.</returns>
        public async Task<bool> UpdatePaymentAsync(int id, PaymentRequestDto updatedPaymentDto)
        {
            try
            {
                var existingPayment = await _dbContext.Payments
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (existingPayment == null)
                    return false;

                var existingEntry = _dbContext.Entry(existingPayment);
                existingEntry.CurrentValues.SetValues(updatedPaymentDto);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes a payment from the database.
        /// </summary>
        /// <param name="id">The ID of the payment to delete.</param>
        /// <returns>True if the deletion was successful, false if the payment was not found.</returns>
        public async Task<bool> DeletePaymentAsync(int id)
        {
            try
            {
                var payment = await _dbContext.Payments
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (payment == null) return false;

                _dbContext.Payments.Remove(payment);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
