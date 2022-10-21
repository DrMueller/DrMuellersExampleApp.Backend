namespace Mmu.DrMuellersExampleApp.Application.Areas.Individuals.Common
{
    public static class IndividualFactory
    {

        public static IReadOnlyCollection<IndividualDto> All =>
            new List<IndividualDto>
            {
                new()
                {
                    FirstName = "Matthias",
                    LastName = "Müller",
                    ID = 1,
                    Birthdate = new DateTime(1986, 12, 29)
                },
                new()
                {
                    FirstName = "Christian",
                    LastName = "Müller",
                    ID = 2,
                    Birthdate = new DateTime(1975, 6, 7)
                },
                new()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    ID = 3,
                    Birthdate = new DateTime(2000, 01, 04)
                }
            };
    }
}