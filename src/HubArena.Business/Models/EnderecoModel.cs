using HubArena.Business.Enums;

namespace HubArena.Business.Models
{
    public class EnderecoModel
    {
        public int IdEndereco { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int? Numero { get; set; }
        public string Complemento { get; set; }
        public string PontoReferencia { get; set; }

        public TipoEnderecoEnum TipoEndereco { get; set; }

        public FuncionarioModel Funcionario { get; set; }
        public QuadraModel Quadra { get; set; }
    }
}
