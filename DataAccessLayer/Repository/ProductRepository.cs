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

        public async Task<int> AddProductAsync(Products entity)
        {
            await AddAsync(entity);
            return entity.Id;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            await DeleteAsync(id);
            return true;
        }

        public Task<IEnumerable<Products>> GetAlProductlAsync(int page, int pageSize, string search, string orderBy)
        {
            return GetAllAsync(page, pageSize, search, "asc");
        }

        public async Task<Products?> GetProductByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<bool> UpdateProductAsync(Products entity)
        {
             await UpdateAsync(entity);
            return true;
        }
    }
}
