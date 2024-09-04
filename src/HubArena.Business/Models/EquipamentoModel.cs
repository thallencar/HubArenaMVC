using HubArena.Business.Enums;

namespace HubArena.Business.Models
{
    public class EquipamentoModel
    {
        public int IdEquipamento { get; set; }
        public string Nome { get; set; }
        public StatusEquipamentoEnum StatusEquipamento { get; set; }

        //1..N
        public int IdEsporte { get; set; } 
        public EsporteModel Esporte { get; set; }

        //N..1
        public IEnumerable<ReservaEquipamentoModel> ReservaEquipamentos { get; set; }
    }
}
