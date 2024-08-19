using HubArena.Business.Enums;

namespace HubArena.Business.Models
{
    public class EquipamentoModel
    {
        public int IdEquipamento { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public StatusEquipamentoEnum StatusEquipamento { get; set; }

        //N..1
        public IEnumerable<EsporteModel> Esportes { get; set; }

        //N..1
        public IEnumerable<ReservaEquipamentoModel> ReservaEquipamentos { get; set; }
    }
}
