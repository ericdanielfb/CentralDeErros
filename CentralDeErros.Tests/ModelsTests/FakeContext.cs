using CentralDeErros.Model.Models;
using System.Collections.Generic;

namespace CentralDeErros.ModelsTests
{
    public class FakeContext 
    {
        public List<User> Users = new List<User>()
        {
            new User () { Id = -1, UserName = "Teste", Email = "Teste@email.com", Password = "123456789", ProfileId = 1},
            new User () { Id = 2, UserName = "T", Email = "Teste@email.com", Password = "123456789", ProfileId = 1},
            new User () { Id = 3, UserName = "Teste", Email = "Teste", Password = "123456789", ProfileId = 1},
            new User () { Id = 4, UserName = "Teste", Email = "Teste@email.com", Password = "12", ProfileId = 1},
            new User () { Id = 5, UserName = "Teste", Email = "Teste@email.com", Password = "123456789", ProfileId = -1},
        };

        public List<Error> Errors = new List<Error>()
        {
            new Error () { Id = -1,Title  = "Teste", Origin  = "Teste@email.com", Details = "123456789", MicrosserviceId = 1, EnviromentId = 1},
            new Error () { Id = 2, Title = "T",      Origin  = "Teste@email.com", Details = "123456789", MicrosserviceId = 1, EnviromentId = 1},
            new Error () { Id = 3, Title = "Teste",  Origin  = "Teste",           Details = "123456789", MicrosserviceId = 1, EnviromentId = 1},
            new Error () { Id = 4, Title = "Teste",  Origin  = "Teste@email.com", Details = "12",        MicrosserviceId = 1, EnviromentId = 1},
            new Error () { Id = 5, Title = "Teste",  Origin  = "Teste@email.com", Details = "123456789", MicrosserviceId = -1, EnviromentId = 1},
        };

        public List<Level> Environments = new List<Level>()
        {
            new Level () { Id = -1, Name = "Teste" },
            new Level () { Id = 2, Name = "T" }
        };

        public List<Model.Models.Environment> Levels = new List<Model.Models.Environment>()
        {
            new Model.Models.Environment () { Id = -1, Phase = "Teste" }, 
            new Model.Models.Environment () { Id = 2, Phase = "T" }
        };

        public List<Profile> Profiles = new List<Profile>()
        {
            new Profile () { Id = -1, Type = "Teste" },
            new Profile () { Id = 2, Type = "T" }
        };

         public List<Microsservice> Microsservices = new List<Microsservice>()
        {
            new Microsservice () { Id = -1,Name = "Teste", Token = "Teste@email.com"},
            new Microsservice () { Id = 2, Name = "T",     Token = "Teste@email.com" },
            new Microsservice () { Id = 3, Name = "Teste", Token = "Teste" }, 
            new Microsservice () { Id = 4, Name = "Teste", Token = "Teste@email.com" },
            new Microsservice () { Id = 5, Name = "Teste", Token = "Teste@email.com" }
        };

    }
}

