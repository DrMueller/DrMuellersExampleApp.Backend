using JetBrains.Annotations;
using Lamar.Microsoft.DependencyInjection;

namespace Mmu.DrMuellersExampleApp;

[PublicAPI]
public static class Program
{
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .UseLamar()
            .ConfigureWebHostDefaults(
                webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
}