using CentralDeErros.Core;
using CentralDeErros.Services.Base;

namespace CentralDeErros.Services
{
    public class MicroserviceService : ServiceBase<MicroserviceService>
    {
        public MicroserviceService(CentralDeErrosDbContext context) : base(context) 
        {
        }
    }
}
