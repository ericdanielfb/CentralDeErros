using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.API.Models
{
    public class Occurrence
    {
        public int OccurrenceId { get; set; }

        public int Origin { get; set; }

        public string Details { get; set; }

        public DateTime OccurrenceDate { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int UserId { get; set; }

    }
}