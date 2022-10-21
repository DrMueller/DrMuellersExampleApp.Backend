using JetBrains.Annotations;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Individuals.Common;

[PublicAPI]
public class IndividualDto
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public long Id { get; set; }

    public DateTime Birthdate { get; set; }
}