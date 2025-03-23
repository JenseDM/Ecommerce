using Ecommerce.Core.Entities;
using Ecommerce.Core.Enums;
using Ecommerce.Core.Formats;

namespace Ecommerce.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAllProductsAsync();
        Task<ProductEntity> GetProductByIdAsync(Guid id);
        Task<IEnumerable<ProductEntity>> GetProductsByCategoryAsync(CategoryProductEnum categoryProductEnum);
        Task<IEnumerable<ProductEntity>> GetProductsByPriceAsync(decimal price);
        Task<IEnumerable<ProductEntity>> GetProductsByBrandAsync(string brandName);
        Task<ResponseFormat<ProductEntity>> AddProductAsync(ProductEntity product);
        Task<ResponseFormat<ProductEntity>> UpdateProductAsync(ProductEntity product);
        Task<ResponseFormat<bool>> DeleteProductAsync(Guid id);
    }
}
