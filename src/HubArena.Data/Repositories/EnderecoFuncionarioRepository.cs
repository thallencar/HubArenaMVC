using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using HubArena.Data.Contexts;

namespace HubArena.Data.Repositories
{

    public class EnderecoFuncionarioRepository : BaseRepository<EnderecoFuncionarioModel>, IEnderecoFuncionarioRepository
    {
        public EnderecoFuncionarioRepository(HubArenaDbContext context) : base(context) { }
        
    }
}
