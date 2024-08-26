using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using HubArena.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HubArena.Data.Repositories
{
    public class EquipamentoRepository : BaseRepository<EquipamentoModel>, IEquipamentoRepository
    {
        public EquipamentoRepository(HubArenaDbContext context) : base (context) { }

        public async Task<IEnumerable<EquipamentoModel>> ObterEquipamentosEsportes()
        {
            return await Db.Equipamentos.AsNoTracking().Include(eq => eq.Esporte).OrderBy(eq => eq.Nome).ToListAsync();
        }
    }
}
