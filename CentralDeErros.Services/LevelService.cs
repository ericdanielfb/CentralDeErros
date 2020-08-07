using CentralDeErros.Core;
using CentralDeErros.Model.Models;
using CentralDeErros.Services.Base;

namespace CentralDeErros.Services
{
    public class LevelService : ServiceBase<Level>
    {
        public LevelService(CentralDeErrosDbContext context) : base(context) 
        {
        }

    }
}
