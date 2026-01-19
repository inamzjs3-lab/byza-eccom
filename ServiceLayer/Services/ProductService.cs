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
                IsApproved = model.IsApproved,
                ProductImage = Convert.FromBase64String(model.ProductImage)
            };
            var result = await _repository.AddAsync(_entity);
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.DeleteAsync(id);
            return entity;
        }

        public async Task<ProductResponceModel> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity != null)
            {

                var Product = new ProductResponceModel
                {
                    Id = entity.Id,
                    Description = entity.ProductDescription,
                    Price = entity.Price,
                    ProductName = entity.ProductName,
                    StockQuantity = entity.StockQuantity,
                    IsApproved = entity.IsApproved,
                    ProductImage = Convert.ToBase64String(entity.ProductImage)

                };
                return Product;
            }
            return new ProductResponceModel();
            
           
        }

        public async Task<List<ProductResponceModel>> GetProductsAsync()
        {
            var productsRm = new List<ProductResponceModel>();
            var products = await _repository.GetAllAsync(0, 100, string.Empty, string.Empty);
            if (products != null)
            {
                foreach (var item in products)
                {
                    var productM = new ProductResponceModel()
                    {
                        Description = item.ProductDescription,
                        Price = item.Price,
                        ProductName = item.ProductName,
                        StockQuantity = item.StockQuantity,
                        IsApproved = item.IsApproved,
                        ProductImage = Convert.ToBase64String(item.ProductImage),


                    };
                    productsRm.Add(productM);
                }
                return productsRm;
            }
            return new List<ProductResponceModel>();
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
                IsApproved = model.IsApproved,
                 ProductImage= Convert.FromBase64String(model.ProductImage),


            };
            var update = await _repository.UpdateAsync(result);
            return update;
        }

    }
}
