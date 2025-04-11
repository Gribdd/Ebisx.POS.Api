namespace Ebisx.POS.Api.Extensions;

internal static class SwaggerFeatureExtensions
{
    public static WebApplication WithSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
}
