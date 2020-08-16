using CentralDeErros.Model.Models;
using System.Collections.Generic;

namespace CentralDeErros.ControllersTests
{
    public class FakeContext 
    {
        public static List<User> Users = new List<User>()
        {
            new User () { Id = 1, UserName = "Teste", Email = "Teste@email.com", Password = "123456789", ProfileId = 1},
            new User () { Id = 2, UserName = "T", Email = "Teste@email.com", Password = "123456789", ProfileId = 1},
            new User () { Id = 3, UserName = "Teste", Email = "Teste", Password = "123456789", ProfileId = 1},
            new User () { Id = 4, UserName = "Teste", Email = "Teste@email.com", Password = "12", ProfileId = 1},
            new User () { Id = 5, UserName = "Teste", Email = "Teste@email.com", Password = "123456789", ProfileId = 1},
        };

        public static List<Error> Errors = new List<Error>()
        {
            new Error () { 
                Id = 1,
                Title = "Teste1",
                Origin  = "Teste1@email.com",
                Details = "Detail1",
                MicrosserviceId = 1,
                EnviromentId = 1,
                LevelId = 1,
                IsArchived = false
            },
            new Error () { 
                Id = 2,
                Title = "Teste2",
                Origin  = "Teste2@email.com",
                Details = "Detail2",
                MicrosserviceId = 1,
                EnviromentId = 1,
                LevelId = 1,
                IsArchived = false
            },
            new Error () { 
                Id = 3, 
                Title = "Teste3", 
                Origin  = "Teste3@email.com", 
                Details = "Detail3", 
                MicrosserviceId = 1, 
                EnviromentId = 1, 
                LevelId = 1, 
                IsArchived = false
            },
            new Error () { 
                Id = 4, 
                Title = "Teste4", 
                Origin  = "Teste4@email.com", 
                Details = "Detail4", 
                MicrosserviceId = 1, 
                EnviromentId = 1, 
                LevelId = 1, 
                IsArchived = false
            },
            new Error () { 
                Id = 5, 
                Title = "Teste5", 
                Origin  = "Teste5@email.com", 
                Details = "Detail5", 
                MicrosserviceId = 1, 
                EnviromentId = 1, 
                LevelId = 1, 
                IsArchived = false
            },
        };

        public static List<Level> Environments = new List<Level>()
        {
            new Level () { Id = 1, Name = "Teste" },
            new Level () { Id = 2, Name = "T" }
        };

        public static List<Model.Models.Environment> Levels = new List<Model.Models.Environment>()
        {
            new Model.Models.Environment () { Id = 1, Phase = "Teste" }, 
            new Model.Models.Environment () { Id = 2, Phase = "T" }
        };

        public static List<Profile> Profiles = new List<Profile>()
        {
            new Profile () { Id = 1, Type = "Teste" },
            new Profile () { Id = 2, Type = "T" }
        };

         public static List<Microsservice> Microsservices = new List<Microsservice>()
        {
            new Microsservice () { Id = 1,Name = "Teste", Token = ""},
            new Microsservice () { Id = 2, Name = "T",     Token = "" },
            new Microsservice () { Id = 3, Name = "Teste", Token = "" }, 
            new Microsservice () { Id = 4, Name = "Teste", Token = "" },
            new Microsservice () { Id = 5, Name = "Teste", Token = "" }
        };

    }
}

