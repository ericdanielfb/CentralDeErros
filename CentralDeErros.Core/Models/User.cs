using System;
using System.Collections.Generic;


namespace CentralDeErros.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public enum Perfil
        {
            Admin,
            User,
            Anonimous
        }

        public int MicrosserviceId { get; set; }

        public ICollection<Occurrence> Occurrences { get; set; }


    }
}