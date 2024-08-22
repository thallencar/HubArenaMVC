using HubArena.Business.Enums;
using HubArena.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HubArena.App.ViewModels
{
    public class ContatoViewModel
    {
        [Key]
        public int IdContato { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(4, ErrorMessage = "O campo DDI deve conter entre {2} e {1} caracteres.", MinimumLength = 1)]
        [DisplayName("DDI")]
        public int Ddi { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(3, ErrorMessage = "O campo DDD deve conter entre {2} e {1} caracteres.", MinimumLength = 1)]
        [DisplayName("DDD")]
        public int Ddd { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(9, ErrorMessage = "O campo DDI deve conter entre {2} e {1} caracteres.", MinimumLength = 9)]
        public string Telefone { get; set; }

        [DisplayName("Tipo de Contato")]
        public TipoContatoEnum TipoContato { get; set; }

        //1..N
        public int IdFuncionario { get; set; }
    }
}
