using System.ComponentModel.DataAnnotations;

namespace CentralDeErros.Transport
{
    public class EnvironmentDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o nome do ambiente", AllowEmptyStrings = false)]
        public string Phase { get; set; }
    }
}
