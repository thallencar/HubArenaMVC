using HubArena.Business.Enums;

namespace HubArena.Business.Models
{
    public abstract class Cadastro
    {
        public int IdCadastro { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public StatusPessoa StatusPessoa { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.UtcNow;

         //1..1
         public int IdEndereco { get; set; }
         public Endereco Endereco { get; set; }
         //N..1
         public IEnumerable<Contato> Contatos { get; set; }
         
    }
}
