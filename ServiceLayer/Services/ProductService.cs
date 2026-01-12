using DataAccessLayer.Contracts;
using EntityLayer;
using ServiceLayer.Contracts;
using ServiceLayer.ServiceModels;

namespace ServiceLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddProductAsync(ProductRequestModel model)
        {
            var _entity = new Products()
            {
                ProductDescription = model.Description,
                Price = model.Price,
                ProductName = model.ProductName,
                StockQuantity = model.StockQuantity,
            };
            var result = await _repository.AddProductAsync(_entity);
            return result;
        }

        public async Task<List<ProductRequestModel>> GetProductsAsync()
        {
            var productsRm = new List<ProductRequestModel>();
            var products = await _repository.GetAllProductsAsync();
            foreach (var item in products)
            {
                var productM = new ProductRequestModel()
                {
                    Description = item.ProductDescription,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    StockQuantity = item.StockQuantity,

                };
                productsRm.Add(productM);
            }
            return productsRm;

        }
    }
}
