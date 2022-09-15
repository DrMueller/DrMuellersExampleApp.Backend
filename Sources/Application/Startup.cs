using Lamar;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Config.Services;
using Mmu.DrMuellersExampleApp.Web.Infrastructure.Initialization;

namespace Mmu.DrMuellersExampleApp;

public class Startup
{
    public Startup()
    {
        Configuration = ConfigurationFactory.Create();
    }

    private IConfiguration Configuration { get; }

    public void Configure(IApplicationBuilder app)
    {
        AppInitialization.InitializeApplication(app, Configuration);
    }

    public void ConfigureContainer(ServiceRegistry services)
    {
        ////IdentityModelEventSource.ShowPII = true;
        ConfigureAuthentication(services);
        ServiceInitialization.InitializeServices(services, Configuration);
    }

    // We do this here in order to let test-web apis overwrite the securit
    protected virtual void ConfigureAuthentication(IServiceCollection services)
    {
        var section = Configuration.GetSection("AppSettings:AzureAd");
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(section, subscribeToJwtBearerMiddlewareDiagnosticsEvents: true);
    }
}