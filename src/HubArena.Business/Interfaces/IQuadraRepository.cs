using HubArena.Business.Models;

namespace HubArena.Business.Interfaces
{
    public interface IQuadraRepository : IBaseRepository<QuadraModel>
    {
        Task<IEnumerable<QuadraModel>> ObterQuadrasEsportes();
        Task<QuadraModel> ObterQuadraEsporte(int id);

    }
}
