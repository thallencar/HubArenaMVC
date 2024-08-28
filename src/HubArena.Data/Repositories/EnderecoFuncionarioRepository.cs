using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using HubArena.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HubArena.Data.Repositories
{

    public class EnderecoFuncionarioRepository : BaseRepository<EnderecoFuncionarioModel>, IEnderecoFuncionarioRepository
    {
        public EnderecoFuncionarioRepository(HubArenaDbContext context) : base(context) { }

        public async Task<EnderecoFuncionarioModel> ObterEnderecoFuncionario(int id)
        {
            return await Db.EnderecoFuncionarios.AsNoTracking().FirstOrDefaultAsync(ef => ef.IdEnderecoFuncionario == id);

        }
    }
}
