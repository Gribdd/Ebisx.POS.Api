using Ebisx.POS.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Ebisx.POS.Api.Extensions;

internal static class InitializeExtensions
{
    public static async Task EnsureCleanDatabaseAsync(this WebApplication app)
    {
        var db = await GetDatabaseContextAsync(app);

        await db.Database.EnsureDeletedAsync();
        await db.Database.EnsureCreatedAsync();
        await ApplicationDbInitializer.SeedAsync(db);
    }

    public static async Task EnsureMigratedDatabaseAsync(this WebApplication app)
    {
        var db = await GetDatabaseContextAsync(app);

        await db.Database.MigrateAsync();
        await ApplicationDbInitializer.SeedAsync(db);
    }

    private static async Task<ApplicationDbContext> GetDatabaseContextAsync(WebApplication app)
    {
        var scope = app.Services.CreateScope();
        return scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }
}
