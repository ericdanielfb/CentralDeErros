using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Core.Models
{
    public class Environment
    {
        public Environment()
        {
            this.Occurrences = new HashSet<Occurrence>();
        }

        public int Id { get; set; }
        public string Phase { get; set; }

        public ICollection<Occurrence> Occurrences { get; set; }
    }
}
