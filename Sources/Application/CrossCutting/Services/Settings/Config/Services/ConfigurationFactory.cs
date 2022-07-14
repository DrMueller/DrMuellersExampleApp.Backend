using Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Models;

namespace Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Config.Services
{
    public static class ConfigurationFactory
    {
        public static IConfiguration Create()
        {
            var configBuilder = new ConfigurationBuilder();
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            configBuilder
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", true, false);

            if (environment == "Development")
            {
                configBuilder.AddUserSecrets<AppSettings>();
            }

            configBuilder.AddEnvironmentVariables();

            return configBuilder.Build();
        }
    }
}