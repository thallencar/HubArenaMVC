using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using HubArena.Data.Contexts;

namespace HubArena.Data.Repositories
{
    public class ReservaRepository : BaseRepository<ReservaModel>, IReservaRepository
    {
        public ReservaRepository(HubArenaDbContext context) : base (context) { }
    }
}
