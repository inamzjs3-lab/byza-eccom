using DataAccessLayer.byzaDbContext;
using DataAccessLayer.Contracts;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        private readonly ByzadbContext _context;
        private readonly DbSet<T> _dbSet;

        public DataRepository(ByzadbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<int> AddAsync(T entity)

        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                var property = entity.GetType().GetProperty("Id");
                if (property != null) { 
                return (int?)property.GetValue(entity) ?? 0;
                }
                throw new Exception("Entity doesn't have Id Property.");
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(int page, int pageSize, string search, string orderBy)
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                var _entity = await _dbSet.FindAsync(id);
                return _entity;
            }
            catch(Exception ex)
            {
                throw new Exception($"Something went wrong. {ex.Message}");
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex) 
            {
                return false;
            }   
        }
    }
}
