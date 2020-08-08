using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralDeErros.Transport
{
    public class MicrosserviceDTO
    {
        [Required]
        public string Name { get; set; }

        public string Token { get; set; }
    }
}
