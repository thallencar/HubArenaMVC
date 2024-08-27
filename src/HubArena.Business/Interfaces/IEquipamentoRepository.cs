using HubArena.Business.Models;

namespace HubArena.Business.Interfaces
{
    public interface IEquipamentoRepository : IBaseRepository<EquipamentoModel>
    {
        Task<IEnumerable<EquipamentoModel>> ObterEquipamentosEsportes();
        Task<EquipamentoModel> ObterEquipamentoEsporte(int id);
    }
}
