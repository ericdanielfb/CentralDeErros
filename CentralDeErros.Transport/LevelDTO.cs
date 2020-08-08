using System.ComponentModel.DataAnnotations;

namespace CentralDeErros.Transport
{
    public class LevelDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o tipo de erro", AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
