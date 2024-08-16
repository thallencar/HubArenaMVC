using HubArena.Business.Enums;

namespace HubArena.Business.Models
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public DateTime Data { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        public StatusReserva StatusReserva { get; set; }

        //1..N 
        public int IdQuadra { get; set; }
        public Quadra Quadra { get; set; }
        
        //1..N 
        public int IdFuncionario { get; set; }
        public Funcionario Funcionario { get; set; }

        //N..1
        public IEnumerable<ReservaEquipamento> ReservaEquipamentos { get; set; }


    }
}
