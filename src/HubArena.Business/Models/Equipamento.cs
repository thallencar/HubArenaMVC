using HubArena.Business.Enums;

namespace HubArena.Business.Models
{
    public class Equipamento
    {
        public int IdEquipamento { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public StatusEquipamento StatusEquipamento { get; set; }

        //N..1
        public IEnumerable<Esporte> Esportes { get; set; }
        //N..1
        public int IdEndereco { get; set; }
        public Endereco Endereco { get; set; }

        //N..1
        public IEnumerable<ReservaEquipamento> ReservaEquipamentos { get; set; }
    }
}
