using System.Text;
using Lamar;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
            AppInitialization.InitializeApplication(app, Configuration);
        }

        public void ConfigureContainer(ServiceRegistry services)
        {
            ConfigureAuthentication(services);
            ServiceInitialization.InitializeServices(services, Configuration);
        }

        // We do this here in order to let test-web apis overwrite the securit
        protected virtual void ConfigureAuthentication(IServiceCollection services)
        {
            var secretKey = Configuration.GetValue<string>("AppSettings:SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);
            services.AddAuthentication(
                    x =>
                    {
                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(
                    x =>
                    {
                        x.RequireHttpsMetadata = false;
                        x.SaveToken = true;
                        x.TokenValidationParameters = new TokenValidationParameters { ValidateIssuerSigningKey = true, IssuerSigningKey = new SymmetricSecurityKey(key), ValidateIssuer = false, ValidateAudience = false };
                    });
        }
    }
}