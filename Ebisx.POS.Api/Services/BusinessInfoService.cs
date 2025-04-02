using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Ebisx.POS.Api.Services.Interfaces.IBusinessInfoService;

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

    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentTypeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PaymentType>> GetAllPaymentTypesAsync()
        {
            return await _dbContext.PaymentTypes.ToListAsync();
        }

        public async Task<PaymentType?> GetPaymentTypeByIdAsync(int id)
        {
            return await _dbContext.PaymentTypes.FindAsync(id);
        }

        public async Task<PaymentType> CreatePaymentTypeAsync(PaymentType paymentType)
        {
            _dbContext.PaymentTypes.Add(paymentType);
            await _dbContext.SaveChangesAsync();
            return paymentType;
        }

        public async Task<bool> UpdatePaymentTypeAsync(int id, PaymentType updatedPaymentType)
        {
            var paymentType = await _dbContext.PaymentTypes.FindAsync(id);
            if (paymentType == null) return false;

            paymentType.Name = updatedPaymentType.Name;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePaymentTypeAsync(int id)
        {
            var paymentType = await _dbContext.PaymentTypes.FindAsync(id);
            if (paymentType == null) return false;

            _dbContext.PaymentTypes.Remove(paymentType);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _dbContext.Payments.Include(p => p.PaymentType).Include(p => p.Order).ToListAsync();
        }

        public async Task<Payment?> GetPaymentByIdAsync(int id)
        {
            return await _dbContext.Payments.Include(p => p.PaymentType).Include(p => p.Order).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            _dbContext.Payments.Add(payment);
            await _dbContext.SaveChangesAsync();
            return payment;
        }

        public async Task<bool> UpdatePaymentAsync(int id, Payment updatedPayment)
        {
            var payment = await _dbContext.Payments.FindAsync(id);
            if (payment == null) return false;

            payment.AmountPaid = updatedPayment.AmountPaid;
            payment.PaymentTypeId = updatedPayment.PaymentTypeId;
            payment.OrderId = updatedPayment.OrderId;
            payment.NonCashPaymentMethodID = updatedPayment.NonCashPaymentMethodID;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            var payment = await _dbContext.Payments.FindAsync(id);
            if (payment == null) return false;

            _dbContext.Payments.Remove(payment);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

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

    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> UpdateCustomerAsync(int id, Customer updatedCustomer)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer == null) return false;

            customer.Name = updatedCustomer.Name;
            customer.Address = updatedCustomer.Address;
            customer.TinNumber = updatedCustomer.TinNumber;
            customer.IdNumber = updatedCustomer.IdNumber;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer == null) return false;

            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

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
