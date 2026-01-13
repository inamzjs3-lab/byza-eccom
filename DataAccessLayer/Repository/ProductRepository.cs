using DataAccessLayer.byzaDbContext;
using DataAccessLayer.Contracts;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class ProductRepository : DataRepository<Products>, IProductRepository
    {
        public ProductRepository(ByzadbContext context) : base(context)
        {
        }

        public async Task<int> AddAsync(Products entity)
        {
            await AddAsync(entity);
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await DeleteAsync(id);
            return true;
        }

        public Task<IEnumerable<Products>> GetAllAsync(int page, int pageSize, string search, string orderBy)
        {
            return GetAllAsync(page, pageSize, search, "asc");
        }

        public async Task<Products?> GetByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Products entity)
        {
             await UpdateAsync(entity);
            return true;
        }
    }
}
