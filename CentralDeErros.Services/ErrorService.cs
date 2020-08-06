using CentralDeErros.Core;
using CentralDeErros.Model.Models;
using CentralDeErros.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Services
{
    public class ErrorService : ServiceBase<Error>
    {
        public ErrorService(CentralDeErrosDbContext context) : base(context)
        {
        }
    }
}
