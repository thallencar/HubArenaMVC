using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using HubArena.Data.Contexts;

namespace HubArena.Data.Repositories
{
    public class EnderecoRepository : BaseRepository<EnderecoModel>, IEnderecoRepository
    {
        public EnderecoRepository(HubArenaDbContext context) : base(context) { }
    }
}
