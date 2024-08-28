using HubArena.Business.Models;

namespace HubArena.Business.Interfaces
{
    public interface IEsporteRepository : IBaseRepository<EsporteModel>
    {
        Task<EsporteModel> ObterEsporte(int id);
    }
}
