using System;
using System.Collections.Generic;


namespace CentralDeErros.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }


    }
}