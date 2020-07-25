using System;
using System.Collections.Generic;

namespace CentralDeErros.Model.Models
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