using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using HubArena.Data.Contexts;

namespace HubArena.Data.Repositories
{
    public class EsporteRepository : BaseRepository<EsporteModel>, IEsporteRepository
    {
        public EsporteRepository(HubArenaDbContext context) : base (context) { }
    }
}
