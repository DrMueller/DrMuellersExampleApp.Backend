using Lamar;
using Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Config.Services;
using Mmu.DrMuellersExampleApp.Web.Infrastructure.Initialization;

namespace Mmu.DrMuellersExampleApp
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup()
        {
            Configuration = ConfigurationFactory.Create();
        }

        public void Configure(IApplicationBuilder app)
        {
            AppInitialization.InitializeApplication(app);
        }

        public void ConfigureContainer(ServiceRegistry services)
        {
            ConfigureAuthentication(services);
            ServiceInitialization.InitializeServices(services, Configuration);
        }

        // We do this here in order to let test-web apis overwrite the securit
        protected virtual void ConfigureAuthentication(IServiceCollection services)
        {
            //services
            //    .AddAuthentication(BasicAuthenticationHandler.SchemeName)
            //    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(BasicAuthenticationHandler.SchemeName, null);
        }
    }
}