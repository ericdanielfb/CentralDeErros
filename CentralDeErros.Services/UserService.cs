using CentralDeErros.Core;
using CentralDeErros.Model.Models;
using CentralDeErros.Services.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.Services
{
    public class UserService
    {
        public ApplicationDbContext Context { get; private set; }

        public UserService(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}

