using CentralDeErros.Core;
using CentralDeErros.Services.Base;


namespace CentralDeErros.Services
{
    public class EnvironmentService:ServiceBase<Model.Models.Environment>
    {
        public EnvironmentService(CentralDeErrosDbContext context) : base(context) 
        {
        }

    }
}
