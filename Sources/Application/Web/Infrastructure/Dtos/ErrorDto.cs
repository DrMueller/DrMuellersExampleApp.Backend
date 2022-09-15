using JetBrains.Annotations;

namespace Mmu.DrMuellersExampleApp.Web.Infrastructure.Dtos;

[PublicAPI]
public class ErrorDto
{
    public string? Message { get; set; }
}