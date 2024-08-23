namespace HubArena.Business.Models
{
    public class EsporteModel
    {
        public int IdEsporte { get; set; }
        public string Nome { get; set; }

        //N..1
        public ICollection<EquipamentoModel> Equipamentos { get; set; }
        //1..N
        public IEnumerable<QuadraModel> Quadras { get; set; }

    }
}
