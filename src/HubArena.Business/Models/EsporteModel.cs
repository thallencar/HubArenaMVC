namespace HubArena.Business.Models
{
    public class EsporteModel
    {
        public int IdEsporte { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        //1..N 
        public int IdEquipamento { get; set; }
        public EquipamentoModel Equipamento { get; set; }
        //N..N 
        public ICollection<QuadraModel> Quadras { get; set; }

    }
}
