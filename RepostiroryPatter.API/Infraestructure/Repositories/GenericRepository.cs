using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RepostiroryPatter.API.Infraestructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ProductContext _context;

        public GenericRepository(ProductContext context)
        {
            _context = context;
        }

        public Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            IQueryable<TEntity> queryEntity = filter == null
                                            ? _context.Set<TEntity>()
                                            : _context.Set<TEntity>().Where(filter);
            return Task.FromResult(queryEntity);

        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                TEntity entity = await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            try
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<bool> Edit(TEntity entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(TEntity entity)
        {
            try
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
