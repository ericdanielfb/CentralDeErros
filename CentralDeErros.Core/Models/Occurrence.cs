using CentralDeErros.API.Models;
using CentralDeErros.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.Core.Models
{
    public class Occurrence
    {
        public int Id { get; set; }

        public int Origin { get; set; }

        public string Details { get; set; }

        public DateTime OccurrenceDate { get; set; }


        public int MicrosserviceId { get; set; }

        public Microsservice Microsservice { get; set; }


        
        public int EnviromentId { get; set; }
        
        public Environment Environment { get; set; }


        public int ErrorId { get; set; }

        public Error Error { get; set; }


    }
}