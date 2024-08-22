using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HubArena.App.ViewModels
{
    public class EnderecoQuadraViewModel
    {
        [Key]
        public int IdEnderecoQuadra { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [RegularExpression(@"^\d{9}$ | ^\d{5}-\d{3}$", ErrorMessage = "O campo Cep deve conter 9 caracteres.")]
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
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Complemento deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Ponto de Referência deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        [DisplayName("Ponto de Referência")]
        public string PontoReferencia { get; set; }

        //1..1
        public int IdQuadra { get; set; }
    }
}
