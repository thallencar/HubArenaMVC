using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using HubArena.Data.Contexts;

namespace HubArena.Data.Repositories
{
    public class ReservaEquipamentoRepository : BaseRepository<ReservaEquipamentoModel>, IReservaEquipamentoRepository
    {
        public ReservaEquipamentoRepository(HubArenaDbContext context) : base (context) { }
    }
}
