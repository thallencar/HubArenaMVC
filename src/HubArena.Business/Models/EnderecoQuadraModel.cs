namespace HubArena.Business.Models
{
    public class EnderecoQuadraModel : EnderecoModel
    {
        public int IdEnderecoQuadra { get; set; }
        //1..1
        public int IdQuadra { get; set; }
        public QuadraModel Quadra { get; set; }
    }
}
