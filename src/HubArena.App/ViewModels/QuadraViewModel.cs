using HubArena.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HubArena.App.ViewModels
{
    public class QuadraViewModel
    {
        [Key]
        public int IdQuadra { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int Capacidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Tipo")]
        public int TipoQuadra { get; set; }
 
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Status")]
        public int StatusQuadra { get; set; }

        //1..1
        public EnderecoViewModel Endereco { get; set; }
        //N..1
        public IEnumerable<ReservaViewModel> Reservas { get; set; }
        //1..N
        public int IdEsporte { get; set; }
    }
}
