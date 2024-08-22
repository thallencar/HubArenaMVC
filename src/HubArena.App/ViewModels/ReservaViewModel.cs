using HubArena.Business.Enums;
using HubArena.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HubArena.App.ViewModels
{
    public class ReservaViewModel
    {
        [Key]
        public int IdReserva { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Horário de Início")]
        public DateTime HorarioInicio { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Horário de Término")]
        public DateTime HorarioFim { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Status")]
        public int StatusReserva { get; set; }

        //1..N 
        public int IdQuadra { get; set; }

        //1..N 
        public int IdFuncionario { get; set; }

        //N..1
        public IEnumerable<ReservaEquipamentoViewModel> ReservaEquipamentos { get; set; }
    }
}
