using AspnetcoreWebapi.Services.Registration;

namespace AspnetcoreWebapi.Refactored.Startup;

public static partial class MiddlewareInitializer
{
    public static WebApplication ConfigureMiddleware(this WebApplication app)
    {
        //app.UseSwagger().UseSwaggerUI();

        app.UseHttpsRedirection();

        return app;
    }
}

