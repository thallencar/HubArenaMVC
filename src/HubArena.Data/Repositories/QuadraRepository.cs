using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using HubArena.Data.Contexts;

namespace HubArena.Data.Repositories
{
    public class QuadraRepository : BaseRepository<QuadraModel>, IQuadraRepository
    {
        public QuadraRepository(HubArenaDbContext context) : base (context) { }
    }
}
