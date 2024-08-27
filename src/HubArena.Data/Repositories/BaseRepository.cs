using HubArena.Business.Interfaces;
using HubArena.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HubArena.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        protected readonly HubArenaDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(HubArenaDbContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }
        public async Task Add(TEntity entity)
        {
            Db.Add(entity);
            await SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            Db.Update(entity);
            await SaveChanges();
        }

        public async Task Delete(TEntity entity)
        {
            Db.Remove(entity);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }


    }
}
