using CentralDeErros.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CentralDeErros.ModelsTests
{
    public class ProfileModelTests : BaseModelTest
    {
        public ProfileModelTests(CentralDeErrosDbContext context) : base(context)
        {
        }

        [Fact(DisplayName = "Atributos do Usuário estão de acordo com as validações")]
        public void ProfileShouldNotBeNull()
        {

            var profiles = context.Profiles.ToList();

            foreach (var profile in profiles) Assert.NotNull(profile);

        }
    }
}
