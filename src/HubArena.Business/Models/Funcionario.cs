namespace HubArena.Business.Models
{
    public class Funcionario : Cadastro
    {
        public int IdFuncionario { get; set; }
        public string Cargo { get; set; }

        //N..1
        public IEnumerable<Reserva> Reservas { get; set; }

    }
}
