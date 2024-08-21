using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using HubArena.Data.Contexts;

namespace HubArena.Data.Repositories
{
    public class ContatoRepository : BaseRepository<ContatoModel>, IContatoRepository
    {
        public ContatoRepository(HubArenaDbContext context) : base(context) { }
    }
}
