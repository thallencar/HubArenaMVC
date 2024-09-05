using HubArena.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HubArena.App.ViewModels
{
    public class EquipamentoViewModel
    {
        [Key]
        public int IdEquipamento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Status"), Range(0,5, ErrorMessage = "O campo Status deve conter entre {1} e {2} caracteres.")] 
        public int StatusEquipamento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Esporte")]
        //1..N
        public int IdEsporte { get; set; }
        public EsporteViewModel Esporte { get; set; }

        //N..1
        public IEnumerable<ReservaEquipamentoViewModel> ReservaEquipamentos { get; set; }

        public IEnumerable<EsporteViewModel> Esportes { get; set; }
    }
}
