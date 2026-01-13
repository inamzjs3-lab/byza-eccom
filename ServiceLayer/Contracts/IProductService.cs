using ServiceLayer.ServiceModels;

namespace ServiceLayer.Contracts
{
    public interface IProductService
    {
        Task<List<ProductResponceModel>> GetProductsAsync();
        Task<int> AddProductAsync(ProductRequestModel model);
        Task<bool> UpdateProductAsync(int id,ProductRequestModel model);
        Task<ProductResponceModel> GetById (int id);
        Task<bool> DeleteAsync(int id);

    }
}
