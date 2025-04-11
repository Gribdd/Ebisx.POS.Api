using AutoMapper;
using Ebisx.POS.Api.DTOs.BusinessInfo;
using Ebisx.POS.Api.DTOs.Customer;
using Ebisx.POS.Api.DTOs.Discount;
using Ebisx.POS.Api.DTOs.DiscountType;
using Ebisx.POS.Api.DTOs.MachineInfo;
using Ebisx.POS.Api.DTOs.NonCashPaymentMethod;
using Ebisx.POS.Api.DTOs.Order;
using Ebisx.POS.Api.DTOs.OrderItem;
using Ebisx.POS.Api.DTOs.Payment;
using Ebisx.POS.Api.DTOs.PaymentType;
using Ebisx.POS.Api.DTOs.Product;
using Ebisx.POS.Api.DTOs.SalesInvoice;
using Ebisx.POS.Api.DTOs.User;
using Ebisx.POS.Api.DTOs.UserRole;
using Ebisx.POS.Api.Entities;

namespace Ebisx.POS.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BusinessInfo, BusinessInfoResponseDto>();
        CreateMap<BusinessInfoRequestDto, BusinessInfo>();
        
        CreateMap<Customer, CustomerResponseDto>();
        CreateMap<CustomerRequestDto, Customer>();
        
        CreateMap<Discount, DiscountResponseDto>();
        CreateMap<DiscountRequestDto, Discount>();
        
        CreateMap<DiscountType, DiscountTypeResponseDto>();
        CreateMap<DiscountTypeRequestDto, DiscountType>();
        
        CreateMap<DiscountType, DiscountTypeResponseDto>();
        CreateMap<DiscountTypeRequestDto, DiscountType>();

        CreateMap<MachineInfo, MachineInfoResponseDto>();
        CreateMap<MachineInfoRequestDto, MachineInfo>(); 
        
        CreateMap<NonCashPaymentMethod, NonCashPaymentMethodResponseDto>();
        CreateMap<NonCashPaymentMethodRequestDto, NonCashPaymentMethod>();
        
        CreateMap<NonCashPaymentMethod, NonCashPaymentMethodResponseDto>();
        CreateMap<NonCashPaymentMethodRequestDto, NonCashPaymentMethod>();

        CreateMap<Order, OrderResponseDto>();
        CreateMap<OrderRequestDto, Order>();

        CreateMap<OrderItem, OrderItemResponseDto>().ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        CreateMap<OrderItemRequestDto, OrderItem>();
        
        CreateMap<Payment, PaymentResponseDto>();
        CreateMap<PaymentRequestDto, Payment>();

        CreateMap<PaymentType, PaymentTypeResponseDto>();
        CreateMap<PaymentTypeRequestDto, PaymentType>();

        CreateMap<Product, ProductResponseDto>();
        CreateMap<ProductRequestDto, Product>();

        CreateMap<SalesInvoice, SalesInvoiceResponseDto>();
        CreateMap<SalesInvoiceRequestDto, SalesInvoice>();
        
        CreateMap<SalesInvoice, SalesInvoiceResponseDto>();
        CreateMap<SalesInvoiceRequestDto, SalesInvoice>();
        
        CreateMap<UserRole, UserRoleResponseDto>();
        CreateMap<UserRoleRequestDto, UserRole>(); 

        CreateMap<User, UserResponseDto>(); 
        CreateMap<UserRequestDto, User>();
    }
}
