using HubArena.Business.Enums;

namespace HubArena.Business.Models
{
    public class Quadra
    {
        public int IdQuadra { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public TipoQuadra TipoQuadra { get; set; }
        public StatusQuadra StatusQuadra { get; set; }

        //1..1
        public int IdEndereco { get; set; }
        public Endereco Endereco { get; set; }
        //N..1
        public IEnumerable<Reserva> Reservas { get; set; }
        //N..N 
        public ICollection<Esporte> Esportes { get; set; }
        
    }
}
