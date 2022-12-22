using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Logging;

namespace Mmu.DrMuellersExampleApp.Web.Infrastructure.Security;

public static class SecurityInitialization
{
    public static void ConfigureAuthentication(IServiceCollection services, IConfiguration config)
    {
        ConfigurePii();
        var section = config.GetSection("AppSettings:AzureAd");

        services.Configure<CookiePolicyOptions>(options =>
        {
            options.MinimumSameSitePolicy = SameSiteMode.Strict;
        });


        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(section, subscribeToJwtBearerMiddlewareDiagnosticsEvents: true);

        ConfigurePolicies(services, section);
    }

    private static void ConfigurePolicies(IServiceCollection services, IConfigurationSection azureAdSection)
    {
        var scopes = azureAdSection.GetValue<string>("Scopes");

        services.AddAuthorization(options =>
        {
            options.AddPolicy(Policies.ApiWrite, policy => policy.RequireRole(Roles.ApiWrite));

            var defaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireScope(scopes!)
                .Build();

            options.DefaultPolicy = defaultPolicy;
        });
    }

    private static void ConfigurePii()
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        IdentityModelEventSource.ShowPII = environment == "Development";
    }
}