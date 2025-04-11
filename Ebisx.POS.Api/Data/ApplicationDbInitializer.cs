using System.Threading.Tasks;
using Ebisx.POS.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Data;

public static class ApplicationDbInitializer
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (!await context.BusinessInfos.AnyAsync(b => b.RegistedName == "JOLLIBEE GEN. MAXILOM"))
        {
            context.BusinessInfos.Add(new BusinessInfo
            {
                RegistedName = "JOLLIBEE GEN. MAXILOM",
                Address = "GENERAL MAXILOM AVE. COR. COGON RAMOS (POB.) CEBU CITY (CAPITAL) CEBU",
                VatTinNumber = "003-460-168-179"
            });
        }

        if (!await context.MachineInfos.AnyAsync(m => m.PosSerialNumber  == "POS-1"))
        {
            context.MachineInfos.Add(new MachineInfo
            {
                PosSerialNumber = "POS-1",
                MinNumber = "22122115450751518",
                AccreditationNumber = "03000033051500000712638",
                DateIssued = new DateTime(2007, 4, 16),
                ValidUntil = new DateTime(2025, 7, 31),
                PtuNumber = "FP122022-125-0362842-00179"
            });
        }

        if (!await context.PaymentTypes.AnyAsync(p => p.Name.ToLower() == "cash"))
        {
            context.PaymentTypes.Add(new PaymentType
            {
                Name = "cash",
            });
        }

        if (!await context.UserRoles.AnyAsync(ur => ur.Role.ToLower() == "employee"))
        {
            context.UserRoles.Add(new UserRole
            {
                Role = "employee"
            });

            context.UserRoles.Add(new UserRole
            {
                Role = "manager"
            });
        }

        if (!await context.Users.AnyAsync())
        {
            var employeeRole = await context.UserRoles.FirstOrDefaultAsync(r => r.Role.ToLower() == "employee");
            var managerRole = await context.UserRoles.FirstOrDefaultAsync(r => r.Role.ToLower() == "manager");

            context.Users.AddRange(
                new User
                {
                    PublicId = "emp001",
                    FName = "John",
                    LName = "Doe",
                    EmailAddress = "john.doe@example.com",
                    Address = "123 Employee St, Cityville",
                    BirthDate = new DateTime(1990, 5, 15),
                    Username = "johndoe",
                    Password = "123", // Store hashed password in real-world apps
                    RoleId = employeeRole?.Id ?? 1 // Assign Employee role (RoleId = 1)
                },
                new User
                {
                    PublicId = "mgr001",
                    FName = "Jane",
                    LName = "Smith",
                    EmailAddress = "jane.smith@example.com",
                    Address = "456 Manager Ave, Cityville",
                    BirthDate = new DateTime(1985, 8, 25),
                    Username = "janesmith",
                    Password = "123", // Store hashed password in real-world apps
                    RoleId = managerRole?.Id ?? 2 // Assign Manager role (RoleId = 2)
                }
            );
        }

        if (!await context.DiscountTypes.AnyAsync(dt => dt.Name.ToLower() == "senior"))
        {
            context.DiscountTypes.Add(new DiscountType
            {
                Name = "senior"
            });
            
            context.DiscountTypes.Add(new DiscountType
            {
                Name = "pwd"
            });
        }

        // Seed Products for Grocery Store
        if (!await context.Products.AnyAsync())
        {
            context.Products.AddRange(
                new Product
                {
                    Name = "Nescafé 3-in-1 Coffee Mix",
                    Barcode = "1234567890123",
                    Quantity = 50,
                    Price = 7.50m, // Price in PHP
                    Vat = 12.0m, // Standard VAT in the Philippines
                    SalesUnit = "Box"
                },
                new Product
                {
                    Name = "Magnum Classic Ice Cream",
                    Barcode = "1234567890456",
                    Quantity = 30,
                    Price = 85.00m, // Price in PHP
                    Vat = 12.0m,
                    SalesUnit = "Piece"
                },
                new Product
                {
                    Name = "Del Monte Pineapple Juice",
                    Barcode = "1234567890789",
                    Quantity = 100,
                    Price = 25.00m, // Price in PHP
                    Vat = 12.0m,
                    SalesUnit = "Can"
                },
                new Product
                {
                    Name = "Purefoods Hotdog",
                    Barcode = "1234567891011",
                    Quantity = 75,
                    Price = 150.00m, // Price in PHP
                    Vat = 12.0m,
                    SalesUnit = "Pack"
                },
                new Product
                {
                    Name = "Nido 3+ Powdered Milk",
                    Barcode = "1234567891345",
                    Quantity = 40,
                    Price = 450.00m, // Price in PHP
                    Vat = 12.0m,
                    SalesUnit = "Can"
                }
            );
        }



        await context.SaveChangesAsync();
    }
}
