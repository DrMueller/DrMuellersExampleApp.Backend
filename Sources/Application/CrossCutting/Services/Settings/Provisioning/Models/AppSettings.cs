using JetBrains.Annotations;

namespace Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Models
{
    [PublicAPI]
    public class AppSettings
    {
        public const string SectionKey = "AppSettings";
        public string SecretKey { get; set; } = null!;
        public string AppBasePath { get; set; } = null!;
        public SecuritySettings SecuritySettings { get; set; } = null!;
    }
}