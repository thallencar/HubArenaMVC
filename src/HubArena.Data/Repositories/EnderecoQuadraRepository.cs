using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using HubArena.Data.Contexts;

namespace HubArena.Data.Repositories
{
    public class EnderecoQuadraRepository : BaseRepository<EnderecoQuadraModel>, IEnderecoQuadraRepository
    {
        public EnderecoQuadraRepository(HubArenaDbContext context) : base(context) { }
    }
}
