using CentralDeErros.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.ModelsTests
{
    public class BaseModelTest
    {
        public readonly CentralDeErrosDbContext context;

        public BaseModelTest(CentralDeErrosDbContext context)
        {
            this.context = context;
        }
    }
}
