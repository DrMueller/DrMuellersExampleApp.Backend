using Lamar;
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
        ServiceInitialization.InitializeServices(services, Configuration);
    }
}