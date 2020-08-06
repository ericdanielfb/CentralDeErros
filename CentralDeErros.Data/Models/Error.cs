using System;

namespace CentralDeErros.Model.Models
{
    public class Error
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Origin { get; set; }
        public string Details { get; set; }
        public DateTime OccurrenceDate { get; set; }

        public int MicrosserviceId { get; set; }
        public Microsservice Microsservice { get; set; }

        public int EnviromentId { get; set; }
        public Environment Environment { get; set; }

        public int LevelId { get; set; }
        public Level Level { get; set; }
    }
}