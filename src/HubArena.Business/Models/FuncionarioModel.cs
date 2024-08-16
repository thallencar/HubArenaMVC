namespace HubArena.Business.Models
{
    public class FuncionarioModel : CadastroModel
    {
        public int IdFuncionario { get; set; }
        public string Cargo { get; set; }

        //N..1
        public IEnumerable<ReservaModel> Reservas { get; set; }

    }
}
