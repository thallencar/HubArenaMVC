namespace HubArena.Business.Models
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string PontoReferencia { get; set; }

        //N..1
        public ICollection<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();
        
        //1..1
        public int IdFuncionario { get; set; }
        public Funcionario Funcionario { get; set; }
        //1..1
        public int IdQuadra { get; set; }
        public Quadra Quadra { get; set; }

    }
}
