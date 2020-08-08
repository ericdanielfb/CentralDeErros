using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralDeErros.Transport
{
    class LevelDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o tipo de erro", AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
