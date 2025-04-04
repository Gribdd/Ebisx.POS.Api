using Ebisx.POS.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<BusinessInfo> BusinessInfos { get; set; }
    public DbSet<MachineInfo> MachineInfos { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<NonCashPaymentMethod> NonCashPaymentMethods { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<DiscountType> DiscountTypes { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<SalesInvoice> SalesInvoices { get; set; }
}
