namespace API.Middelwares;
    public static class ExceptionMiddlewareExtensions
    {
    public static void ConfigureCustomExceptionMiddelware(this IApplicationBuilder app)
    {
        app.UseMiddleware<CustomGlobalExceptionHandlerMiddleware>();
    }
    }

