using System.Linq.Expressions;

namespace RepostiroryPatter.API.Infraestructure.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter = null);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> Create(TEntity entity);
        Task<bool> Edit(TEntity entity);
        Task<bool> Delete(TEntity entity);

    }
}
