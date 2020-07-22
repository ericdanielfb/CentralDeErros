using CentralDeErros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Threading.Tasks;

namespace CentralDeErros.API.Models
{
    public class Error
    {

        public Error()
        {
            Occurrences = new HashSet<Occurrence>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int LevelId { get; set; }
        public Level Level { get; set; }

        public ICollection<Occurrence> Occurrences { get; set; }
    }
}