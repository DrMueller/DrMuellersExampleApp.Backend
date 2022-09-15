using JetBrains.Annotations;
using Mmu.DrMuellersExampleApp.Web.Infrastructure.ExceptionHandling.Middlewares;

namespace Mmu.DrMuellersExampleApp.Web.Infrastructure.ExceptionHandling.Initialization;

[PublicAPI]
public static class ApplicationInitialization
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

        return app;
    }
}