namespace HubArena.Business.Models
{
    public class ReservaEquipamentoModel
    {
        public int IdReservaEquipamento { get; set; }
        public int Quantidade { get; set; }

        //1..N
        public int IdReserva { get; set; }
        public ReservaModel Reserva { get; set; }

        //1..N
        public int IdEquipamento { get; set; }
        public EquipamentoModel Equipamento { get; set; }
    }

}
