using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using HubArena.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HubArena.Data.Repositories
{
    public class QuadraRepository : BaseRepository<QuadraModel>, IQuadraRepository
    {
        public QuadraRepository(HubArenaDbContext context) : base (context) { }

        public async Task<QuadraModel> ObterQuadraEsporte(int id)
        {
            return await Db.Quadras.AsNoTracking().Include(q => q.Esporte).FirstOrDefaultAsync(q => q.IdQuadra == id);
        }

        public async Task<IEnumerable<QuadraModel>> ObterQuadrasEsportes()
        {
            return await Db.Quadras.AsNoTracking().Include(q => q.Esporte).OrderBy(q => q.Nome).ToListAsync();
        }

    }
}
