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
            var result = await _repository.AddAsync(_entity);
            return result;
        }

        public async Task<ProductRequestModel> GetById(int id)
        {
            var Product = await _repository.GetByIdAsync(id);
            var entity = new ProductRequestModel
            {
                Description = Product.ProductDescription,
                Price = Product.Price,
                ProductName = Product.ProductName,
                StockQuantity = Product.StockQuantity,

            };
            return entity;
        }

        public async Task<List<ProductRequestModel>> GetProductsAsync()
        {
            var productsRm = new List<ProductRequestModel>();
            var products = await _repository.GetAllAsync(0, 100, string.Empty, string.Empty);
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

        public async Task<bool> UpdateProductAsync(int id, ProductRequestModel model)
        {
            var result = new Products
            {
                Id = id,
                ProductDescription = model.Description,
                Price = model.Price,
                ProductName = model.ProductName,
                StockQuantity = model.StockQuantity,
            };
            var update = await _repository.UpdateAsync(result);
            return update;
        }
    }
}
