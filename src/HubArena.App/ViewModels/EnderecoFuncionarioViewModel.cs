using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HubArena.App.ViewModels
{
    public class EnderecoFuncionarioViewModel
    {
        [Key]
        public int IdEnderecoFuncionario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [RegularExpression(@"^\d{8}$|^\d{5}-\d{3}$", ErrorMessage = "O campo Cep deve conter 8 caracteres.")]
        public string Cep { get; set; } 

        [Required(ErrorMessage = "Campo obrigatório.")]
        [RegularExpression(@"^[A-Z]{2}$", ErrorMessage = "O campo Estado deve conter 2 caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Cidade deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Bairro deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Logradouro deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Logradouro { get; set; }

        [DisplayName("Número")]
        public int? Numero { get; set; }

        [StringLength(50, ErrorMessage = "O campo Complemento deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string? Complemento { get; set; }

        [StringLength(100, ErrorMessage = "O campo Ponto de Referência deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        [DisplayName("Ponto de Referência")]
        public string? PontoReferencia { get; set; }

    }
}
