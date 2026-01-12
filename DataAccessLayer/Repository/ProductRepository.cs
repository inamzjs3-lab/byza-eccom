using DataAccessLayer.byzaDbContext;
using DataAccessLayer.Contracts;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ByzadbContext _context;
        public ProductRepository(ByzadbContext context)
        {
            _context = context;
        }

        public async Task<int> AddProductAsync(Products entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<List<Products>> GetAllProductsAsync()
        {
            var record = await _context.Products.ToListAsync();
            return record;
        }
    }
}
