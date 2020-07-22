using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.API.Models
{
    public class Level
    {
        public Level()
        {
            this.Errors = new HashSet<Error>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Error> Errors { get; set; }
    }
}