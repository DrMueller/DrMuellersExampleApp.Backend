﻿using Microsoft.Extensions.FileProviders;
using Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Models;
using Mmu.DrMuellersExampleApp.Web.Infrastructure.ExceptionHandling.Initialization;
using Mmu.DrMuellersExampleApp.Web.Infrastructure.Output;

namespace Mmu.DrMuellersExampleApp.Web.Infrastructure.Initialization
{
    internal static class AppInitialization
    {
        internal static void InitializeApplication(
            IApplicationBuilder app,
            IConfiguration configuration)
        {
            var basePath = configuration.GetSection($"{AppSettings.SectionKey}:{nameof(AppSettings.AppBasePath)}").Get<string>();
            app.UsePathBase(basePath);

            Console.WriteLine($"Using basePath {basePath}");

            app.UseMiddleware<ConsoleOutputMiddleware>();
            app.UseGlobalExceptionHandler();
            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = "/api"
            });

            app.UseSwagger();
            app.UseSwaggerUI(
                config =>
                {
                    config.SwaggerEndpoint("/swagger/v1/swagger.json", "DrMuellersExampleApp API");
                });

            app.UseCors("All");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}