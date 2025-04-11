using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Services;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IBusinessInfoService, BusinessInfoService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IDiscountService, DiscountService>();
        services.AddScoped<IDiscountTypeService, DiscountTypeService>();
        services.AddScoped<IMachineInfoService, MachineInfoService>();
        services.AddScoped<INonCashPaymentMethodService, NonCashPaymentMethodService>();
        services.AddScoped<IPaymentTypeService, PaymentTypeService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ISalesInvoiceService, SalesInvoiceService>();
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = GetDatabaseConnectionString(configuration);
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        return services;
    }

    private static string GetDatabaseConnectionString(IConfiguration configuration)
    {
        return configuration.GetConnectionString("DefaultConnection")!;
    }
}
