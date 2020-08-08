using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralDeErros.Transport
{
    public class MicrosserviceDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "É obrigatório informar um microsservice", AllowEmptyStrings = false)]
        public string Name { get; set; }

        public string Token { get; set; }
    }
}
