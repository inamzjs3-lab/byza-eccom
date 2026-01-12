using EntityLayer;

namespace DataAccessLayer.Contracts
{
    public interface IProductRepository
    {
        Task<List<Products>> GetAllProductsAsync();
        Task<int> AddProductAsync(Products entity);
    }
}
