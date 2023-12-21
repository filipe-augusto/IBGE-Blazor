using System.ComponentModel.DataAnnotations;

namespace IBGE_Blazor.Models
{
    public class Localidade
    {
        [Required(ErrorMessage = "Codigo da cidade é necessario")] 
        [MaxLength(7, ErrorMessage = "Digite 7 caracteres para o codigo da cidade")]
        [MinLength(7, ErrorMessage = "Digite 7 caracteres para o codigo da cidade")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Estado é necessario")]
        [MaxLength(2, ErrorMessage = "Digite no maximo 2 caracteres para o estado")]
        [MinLength(2, ErrorMessage = "Digite no minimo 2 caracteres para o estado")]
        public string State { get; set; }


        [Required(ErrorMessage = "Cidade é necessario")]
        [MinLength(2, ErrorMessage = "Digite no minimo 2 caracteres para a cidade")]
        public string City { get; set; }

    }
}
