using HubArena.Business.Interfaces;
using HubArena.Business.Models;
using HubArena.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HubArena.Data.Repositories
{
    public class FuncionarioRepository : BaseRepository<FuncionarioModel>, IFuncionarioRepository
    {
        public FuncionarioRepository(HubArenaDbContext context) : base(context) { }

        public async Task<FuncionarioModel> ObterFuncionario(int id)
        {
            return await Db.Funcionarios.AsNoTracking().FirstOrDefaultAsync(f => f.IdFuncionario == id);    
        }

        public async Task<FuncionarioModel> ObterFuncionarioEndereco(int id)
        {
            return await Db.Funcionarios.AsNoTracking().Include(f => f.Endereco).FirstOrDefaultAsync(f => f.IdFuncionario == id);
        }

        public async Task<IEnumerable<FuncionarioModel>> ObterFuncionariosEnderecos()
        {
            return await Db.Funcionarios.AsNoTracking().Include(f => f.Endereco).ToListAsync();
        }
    }
}
