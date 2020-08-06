using System;
using System.Collections.Generic;

namespace CentralDeErros.Model.Models
{
    public class Level
    {
        public Level()
        {
            this.Occurrences = new HashSet<Occurrence>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Occurrence> Occurrences { get; set; }
    }
}