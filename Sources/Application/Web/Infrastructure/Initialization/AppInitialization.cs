using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Models;
using Mmu.DrMuellersExampleApp.Web.Infrastructure.ExceptionHandling.Initialization;
using Mmu.DrMuellersExampleApp.Web.Infrastructure.Output;

namespace Mmu.DrMuellersExampleApp.Web.Infrastructure.Initialization;

internal static class AppInitialization
{
    internal static void InitializeApplication(
        IApplicationBuilder app,
        IConfiguration configuration)
    {
        var basePath = configuration.GetSection($"{AppSettings.SectionKey}:{nameof(AppSettings.AppBasePath)}")
            .Get<string>();
        app.UsePathBase(basePath);

        app.UseMiddleware<ConsoleOutputMiddleware>();
        app.UseGlobalExceptionHandler();
        app.UseSwagger();
        app.UseSwaggerUI(
            config => { config.SwaggerEndpoint($"{basePath}/swagger/v1/swagger.json", "DrMuellersExampleApp API"); });

        app.UseCors("All");
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapHealthChecks("/api/hc", new HealthCheckOptions
                {
                    Predicate = _ => true
                });
                endpoints.MapControllers();
            });
    }
}