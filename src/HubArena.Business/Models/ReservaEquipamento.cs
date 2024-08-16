using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubArena.Business.Models
{
    public class ReservaEquipamento
    {
        public int IdReservaEquipamento { get; set; }
        public int Quantidade { get; set; }

        //1..N
        public int IdReserva { get; set; }
        public Reserva Reserva { get; set; }

        //1..N
        public int IdEquipamento { get; set; }
        public Equipamento Equipamento { get; set; }
    }

}
