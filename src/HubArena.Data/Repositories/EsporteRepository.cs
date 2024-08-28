using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using HubArena.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HubArena.Data.Repositories
{
    public class EsporteRepository : BaseRepository<EsporteModel>, IEsporteRepository
    {
        public EsporteRepository(HubArenaDbContext context) : base (context) { }

        public async Task<EsporteModel> ObterEsporte(int id)
        {
            return await Db.Esportes.AsNoTracking().FirstOrDefaultAsync(es => es.IdEsporte == id);
        }
    }
}
