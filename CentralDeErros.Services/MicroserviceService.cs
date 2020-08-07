using CentralDeErros.Core;
using CentralDeErros.Model.Models;
using CentralDeErros.Services.Base;

namespace CentralDeErros.Services
{
    public class MicrosserviceService : ServiceBase<Microsservice>
    {
        public MicrosserviceService(CentralDeErrosDbContext context) : base(context) 
        {
        }
    }
}
