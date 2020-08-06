using System;
using System.Collections.Generic;

namespace CentralDeErros.Model.Models
{
    public class Error
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int LevelId { get; set; }
        public Level Level { get; set; }

        public Occurrence Occurrence { get; set; }

    }
}