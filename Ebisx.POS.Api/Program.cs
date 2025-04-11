using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Extensions;
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
        app.WithSwagger();
        await app.EnsureCleanDatabaseAsync();
    }   
    else
    {
        await app.EnsureMigratedDatabaseAsync();
    }


    app.MapControllers();
    app.UseHttpsRedirection();
    app.UseAuthorization();

    await app.RunAsync();
}



