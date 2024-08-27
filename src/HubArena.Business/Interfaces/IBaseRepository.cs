using System.Linq.Expressions;

namespace HubArena.Business.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task <IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
