using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplicationServices()
        .AddAutoMapper(typeof(Program))
        .AddDatabase(builder.Configuration)
        .AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddConsole();
            loggingBuilder.AddDebug();
        })
        .AddSwaggerGen()
        .AddControllers();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    try
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await db.Database.MigrateAsync();
        await ApplicationDbInitializer.SeedAsync(db);
    }
    catch (Exception ex)
    {
        // Log or handle error here
        Console.WriteLine($"Migration failed: {ex.Message}");
    }

    app.MapControllers();
    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.Run();
}



