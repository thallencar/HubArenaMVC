using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using HubArena.Data.Contexts;

namespace HubArena.Data.Repositories
{
    public class FuncionarioRepository : BaseRepository<FuncionarioModel>, IFuncionarioRepository
    {
        public FuncionarioRepository(HubArenaDbContext context) : base(context) { }
    }
}
