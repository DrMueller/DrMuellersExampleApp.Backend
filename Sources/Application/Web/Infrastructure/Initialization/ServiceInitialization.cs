using System.Diagnostics;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Models;
using Mmu.DrMuellersExampleApp.Web.Infrastructure.Security;

namespace Mmu.DrMuellersExampleApp.Web.Infrastructure.Initialization;

internal static class ServiceInitialization
{
    internal static void InitializeServices(ServiceRegistry services, IConfiguration configuration)
    {
        services.Scan(
            scanner =>
            {
                scanner.AssembliesFromApplicationBaseDirectory();
                scanner.LookForRegistries();
            });

        SecurityInitialization.ConfigureAuthentication(services, configuration);

        services.AddHealthChecks();
        services.AddApplicationInsightsTelemetry();
        services.AddControllers();

        services.Configure<AppSettings>(configuration.GetSection(AppSettings.SectionKey));

        ConfigureSwagger(services);
        ConfigureCors(services);
        ConfigureHsts(services);
    }

    private static void ConfigureHsts(IServiceCollection services)
    {
        services.AddHsts(options =>
        {
            options.Preload = true;
            options.IncludeSubDomains = true;
            options.MaxAge = TimeSpan.FromDays(365);
        });
    }

    private static void ConfigureCors(IServiceCollection services)
    {
        services.AddCors(
            options =>
            {
                options.AddPolicy(
                    "All",
                    builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod());
            });
    }

    private static void ConfigureSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(
            c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "CleanDddArchitecture API",
                        Description =
                            @"<p>This is the CleanDddArchitecture API. Below you find the currently implemented endpoints with the according request method(s).</p>"
                    });

                c.AddSecurityDefinition(
                    "Basic",
                    new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "Basic"
                    });

                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Basic"
                                },
                                Scheme = "Basic",
                                Name = "Basic",
                                In = ParameterLocation.Header
                            },
                            new List<string>()
                        }
                    });
            });
    }
}