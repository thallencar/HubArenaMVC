using HubArena.Business.Enums;
using HubArena.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HubArena.App.ViewModels
{
    public class FuncionarioViewModel
    {
        [Key]
        public int IdFuncionario { get; set; }

        [Required (ErrorMessage = "Campo obrigatório.")]
        [StringLength(150, ErrorMessage = "O campo Nome deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Campo obrigatório.")]
        [StringLength(90, ErrorMessage = "O campo Cargo deve conter entre {2} e {1} caracteres.", MinimumLength = 10 )]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(11, ErrorMessage = "O campo Documento deve conter entre {2} e {1} caracteres.", MinimumLength = 9)]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName ("Data de Nascimento"), DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato inválido de e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(30, ErrorMessage = "O campo Usuário deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        [DisplayName("Usuário")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(16, ErrorMessage = "O campo Senha deve conter entre {2} e {1} caracteres.", MinimumLength = 6)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Status")]
        [ScaffoldColumn(false)]
        public int StatusPessoa { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataRegistro { get; set; } = DateTime.UtcNow;

        //1..1
        public EnderecoViewModel Endereco { get; set; }
        //N..1
        public IEnumerable<ContatoViewModel> Contatos { get; set; }

        //N..1
        public IEnumerable<ReservaViewModel> Reservas { get; set; }
    }
}
