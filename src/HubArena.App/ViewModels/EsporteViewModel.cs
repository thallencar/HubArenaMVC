using HubArena.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HubArena.App.ViewModels
{
    public class EsporteViewModel
    {
        [Key]
        public int IdEsporte { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo nome deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        //1..N
        public IEnumerable<QuadraViewModel> Quadras { get; set; }

        public IEnumerable<EquipamentoViewModel> Equipamentos { get; set; }
    }
}
