using EntityLayer;

namespace DataAccessLayer.Contracts
{
    public interface IProductRepository:IDataRepository<Products>
    {
        //Task<List<Products>> GetAllProductsAsync();
        //Task<int> AddProductAsync(Products entity);
    }
}
