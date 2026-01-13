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

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Products>> GetAllAsync(int page, int pageSize, string search, string orderBy)
        {
            return GetAllAsync(page, pageSize, search, "asc");
        }

        public Task<Products?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Products entity)
        {
            throw new NotImplementedException();
        }
    }
}
