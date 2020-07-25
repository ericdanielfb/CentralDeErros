using System;
using System.Collections.Generic;

namespace CentralDeErros.Model.Models
{
    public class Microsservice
    {
        public Microsservice()
        {
            Occurrences = new HashSet<Occurrence>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public ICollection<Occurrence> Occurrences { get; set; }
    }
}
