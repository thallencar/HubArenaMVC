namespace HubArena.Business.Models
{
    public class Esporte
    {
        public int IdEsporte { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        //1..N 
        public int IdEquipamento { get; set; }
        public Equipamento Equipamento { get; set; }
        //N..N 
        public ICollection<Quadra> Quadras { get; set; }

    }
}
