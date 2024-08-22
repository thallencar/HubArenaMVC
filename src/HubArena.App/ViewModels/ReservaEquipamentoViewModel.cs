using HubArena.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace HubArena.App.ViewModels
{
    public class ReservaEquipamentoViewModel
    {
        [Key]
        public int IdReservaEquipamento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int Quantidade { get; set; }

        //1..N
        public int IdReserva { get; set; }

        //1..N
        public int IdEquipamento { get; set; }
    }
}
