using HubArena.Business.Enums;

namespace HubArena.Business.Models
{
    public class ReservaModel
    {
        public int IdReserva { get; set; }
        public DateTime Data { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        public StatusReservaEnum StatusReserva { get; set; }

        //1..N 
        public int IdQuadra { get; set; }
        public QuadraModel Quadra { get; set; }
        
        //1..N 
        public int IdFuncionario { get; set; }
        public FuncionarioModel Funcionario { get; set; }

        //N..1
        public IEnumerable<ReservaEquipamentoModel> ReservaEquipamentos { get; set; }


    }
}
