using HubArena.Business.Models;

namespace HubArena.Business.Interfaces
{
    public interface IFuncionarioRepository : IBaseRepository<FuncionarioModel>
    {
        Task<FuncionarioModel> ObterFuncionario(int id);
        Task<FuncionarioModel> ObterFuncionarioEndereco(int id);
    }
}
