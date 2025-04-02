using Ebisx.POS.Api.Entities;

namespace Ebisx.POS.Api.Services.Interfaces
{
    public interface IBusinessInfoService
    {
        Task<IEnumerable<BusinessInfo>> GetAllBusinessInfoAsync();
        Task<BusinessInfo?> GetBusinessInfoByIdAsync(int id);
        Task<BusinessInfo> CreateBusinessInfoAsync(BusinessInfo businessInfo);
        Task<bool> UpdateBusinessInfoAsync(int id, BusinessInfo businessInfo);
        Task<bool> DeleteBusinessInfoAsync(int id);
    }

    public interface IMachineInfoService
    {
        Task<IEnumerable<MachineInfo>> GetAllMachineInfoAsync();
        Task<MachineInfo?> GetMachineInfoByIdAsync(int id);
        Task<MachineInfo> CreateMachineInfoAsync(MachineInfo machineInfo);
        Task<bool> UpdateMachineInfoAsync(int id, MachineInfo machineInfo);
        Task<bool> DeleteMachineInfoAsync(int id);
    }

    public interface IPaymentTypeService
    {
        Task<IEnumerable<PaymentType>> GetAllPaymentTypesAsync();
        Task<PaymentType?> GetPaymentTypeByIdAsync(int id);
        Task<PaymentType> CreatePaymentTypeAsync(PaymentType paymentType);
        Task<bool> UpdatePaymentTypeAsync(int id, PaymentType paymentType);
        Task<bool> DeletePaymentTypeAsync(int id);
    }

    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAllPaymentsAsync();
        Task<Payment?> GetPaymentByIdAsync(int id);
        Task<Payment> CreatePaymentAsync(Payment payment);
        Task<bool> UpdatePaymentAsync(int id, Payment payment);
        Task<bool> DeletePaymentAsync(int id);
    }

    public interface INonCashPaymentMethodService
    {
        Task<IEnumerable<NonCashPaymentMethod>> GetAllNonCashPaymentMethodsAsync();
        Task<NonCashPaymentMethod?> GetNonCashPaymentMethodByIdAsync(int id);
        Task<NonCashPaymentMethod> CreateNonCashPaymentMethodAsync(NonCashPaymentMethod nonCashPaymentMethod);
        Task<bool> UpdateNonCashPaymentMethodAsync(int id, NonCashPaymentMethod nonCashPaymentMethod);
        Task<bool> DeleteNonCashPaymentMethodAsync(int id);
    }

    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(int id, Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
    }

    public interface IDiscountService
    {
        Task<IEnumerable<Discount>> GetAllDiscountsAsync();
        Task<Discount?> GetDiscountByIdAsync(int id);
        Task<Discount> CreateDiscountAsync(Discount discount);
        Task<bool> UpdateDiscountAsync(int id, Discount discount);
        Task<bool> DeleteDiscountAsync(int id);
    }

    public interface IDiscountTypeService
    {
        Task<IEnumerable<DiscountType>> GetAllDiscountTypesAsync();
        Task<DiscountType?> GetDiscountTypeByIdAsync(int id);
        Task<DiscountType> CreateDiscountTypeAsync(DiscountType discountType);
        Task<bool> UpdateDiscountTypeAsync(int id, DiscountType discountType);
        Task<bool> DeleteDiscountTypeAsync(int id);
    }
}
