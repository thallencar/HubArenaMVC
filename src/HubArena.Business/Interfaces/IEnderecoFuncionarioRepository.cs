using HubArena.Business.Models;

namespace HubArena.Business.Interfaces
{
    public interface IEnderecoFuncionarioRepository : IBaseRepository<EnderecoFuncionarioModel>
    {
        Task<EnderecoFuncionarioModel> ObterEnderecoFuncionario(int id);
    }
}
