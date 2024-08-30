using HubArena.Business.Enums;

namespace HubArena.Business.Models
{
    public class FuncionarioModel
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Documento { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public StatusPessoaEnum StatusPessoa { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.UtcNow;

        //public TipoUsuarioEnum TipoUsuario { get; set; }

        //1..1
        public int IdEndereco { get; set; } 
        public EnderecoModel Endereco{ get; set; }

        //N..1
        public IEnumerable<ContatoModel> Contatos { get; set; }

        //N..1
        public IEnumerable<ReservaModel> Reservas { get; set; }

    }
}
