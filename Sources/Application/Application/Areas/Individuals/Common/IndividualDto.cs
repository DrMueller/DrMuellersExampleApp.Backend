using JetBrains.Annotations;

namespace Mmu.DrMuellersExampleApp.Application.Areas.Individuals.Common
{
    [PublicAPI]
    public class IndividualDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long ID { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
