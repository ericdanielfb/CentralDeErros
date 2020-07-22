using CentralDeErros.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.Core.Models
{
    public class Microsservice
    {
        public Microsservice()
        {
            Occurrences = new HashSet<Occurrence>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Occurrence> Occurrences { get; set; }

    }
}
