namespace HubArena.Business.Models
{
    public class EnderecoFuncionarioModel : EnderecoModel
    {
        public int IdEnderecoFuncionario { get; set; }


        //1..1

        public int? IdFuncionario { get; set; } 
        public FuncionarioModel Funcionario { get; set; }


    }
}
