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
    }
}

