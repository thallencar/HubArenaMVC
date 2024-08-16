using HubArena.Business.Enums;

namespace HubArena.Business.Models
{
    public class ContatoModel
    {
        public int IdContato { get; set; }
        public int Ddd { get; set; }
        public int Ddi { get; set; }
        public string Telefone { get; set; }
        public TipoContatoEnum TipoContato { get; set; }

        //1..N
        public int IdFuncionario { get; set; }
        public FuncionarioModel Funcionario { get; set; }

    }
}
