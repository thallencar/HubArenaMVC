using HubArena.Business.Enums;

namespace HubArena.Business.Models
{
    public class Contato
    {
        public int IdContato { get; set; }
        public int Ddd { get; set; }
        public int Ddi { get; set; }
        public string Telefone { get; set; }
        public TipoContato TipoContato { get; set; }

        //1..N
        public int IdFuncionario { get; set; }
        public Funcionario Funcionario { get; set; }

    }
}
