using HubArena.Business.Enums;

namespace HubArena.Business.Models
{
    public class QuadraModel
    {
        public int IdQuadra { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public TipoQuadraEnum TipoQuadra { get; set; }
        public StatusQuadraEnum StatusQuadra { get; set; }

        //1..1
        public int IdEndereco { get; set; }
        public EnderecoModel Endereco { get; set; }
        //N..1
        public IEnumerable<ReservaModel> Reservas { get; set; }
        //1..N
        public int IdEsporte { get; set; }
        public EsporteModel Esporte { get; set; }

    }
}
