using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralDeErros.Transport
{
    public  class EnvironmentDTO
    {
        public int Id { get; set; }

        [Required]
        public string Phase { get; set; }
    }
}
