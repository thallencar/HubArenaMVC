using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using HubArena.Data.Contexts;

namespace HubArena.Data.Repositories
{
    public class EquipamentoRepository : BaseRepository<EquipamentoModel>, IEquipamentoRepository
    {
        public EquipamentoRepository(HubArenaDbContext context) : base (context) { }
    }
}
