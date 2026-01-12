using ServiceLayer.ServiceModels;

namespace ServiceLayer.Contracts
{
    public interface IProductService
    {
        Task<List<ProductRequestModel>> GetProductsAsync();
        Task<int> AddProductAsync(ProductRequestModel model);
    }
}
