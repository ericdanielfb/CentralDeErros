using CentralDeErros.Core;
using CentralDeErros.Model.Models;
using System.Linq;
using Xunit;

namespace CentralDeErros.ModelsTests
{
    public class OccurrenceModelTests : BaseModelTest
    {
        public OccurrenceModelTests(CentralDeErrosDbContext context) : base(context)
        {
        }

        [Fact(DisplayName = "Occorrências não podem ser nulas")]
        public void OccurrenceShouldNotBeNull()
        {
            var occurrences = context.Occurrences.ToList();

            foreach (var occurrence in occurrences) Assert.NotNull(occurrence);
        }
    }
}
