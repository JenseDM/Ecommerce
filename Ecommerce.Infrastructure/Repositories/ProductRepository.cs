using Ecommerce.Core.Entities;
using Ecommerce.Core.Enums;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
        {
            if(_context.Products == null)
            {
                throw new InvalidOperationException("No se han encontrado productos");
            }

            var products =  await _context.Products.ToListAsync();
            return products;
        }

        public async Task<ProductEntity> GetProductByIdAsync(Guid id)
        {
            if (_context.Products == null)
            {
                throw new InvalidOperationException("No se han encontrado productos");
            }
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                throw new Exception("El producto no existe");
            }

            return product;
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsByCategoryAsync(CategoryProductEnum categoryProductEnum)
        {
            if (_context.Products == null)
            {
                throw new InvalidOperationException("No se han encontrado productos");
            }
            var products = await _context.Products.Where(p => p.Category == categoryProductEnum).ToListAsync();

            return products;
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsByPriceAsync(decimal price)
        {
            if (_context.Products == null)
            {
                throw new InvalidOperationException("No se han encontrado productos");
            }
            var products = await _context.Products.Where(p => p.Price == price).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsByBrandAsync(string brandName)
        {
            if (_context.Products == null)
            {
                throw new InvalidOperationException("No se han encontrado productos");
            }
            var products = await _context.Products.Where(p => p.Brand == brandName).ToListAsync();
            return products;
        }

        public async Task<ResponseFormat<ProductEntity>> AddProductAsync(ProductEntity product)
        {
            if (_context.Products == null)
            {
                throw new InvalidOperationException("No se han encontrado productos");
            }
            var productExist = await _context.Products.FirstOrDefaultAsync(p => p.Name == product.Name);
            if (productExist != null)
            {
                throw new InvalidOperationException("El producto ya existe");
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            var response =  new ResponseFormat<ProductEntity>
                {
                    Message = "Producto añadido correctamente",
                    Success = true,
                    Data = product
                };
            return response;
        }

        public async Task<ResponseFormat<ProductEntity>> UpdateProductAsync(ProductEntity product)
        {
            if (_context.Products == null)
            {
                throw new InvalidOperationException("No se han encontrado productos");
            }
            var productToUpdate = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (productToUpdate == null)
            {
               throw new InvalidOperationException("El producto no existe");
            }

            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Brand = product.Brand;
            productToUpdate.Category = product.Category;
            productToUpdate.Description = product.Description;
            productToUpdate.ImageUrl = product.ImageUrl;
            productToUpdate.Stock = product.Stock;
            productToUpdate.UpdatedAt = DateTime.Now;

            _context.Products.Update(productToUpdate);
            await _context.SaveChangesAsync();
            var response = new ResponseFormat<ProductEntity>
            {
                Message = "Producto actualizado correctamente",
                Success = true,
                Data = productToUpdate
            };
            return response;
        }

        public async Task<ResponseFormat<bool>> DeleteProductAsync(Guid id)
        {
            if (_context.Products == null)
            {
                throw new InvalidOperationException("No se han encontrado productos");
            }
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                throw new InvalidOperationException("El producto no existe");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            var response = new ResponseFormat<bool>
            {
                Message = "Producto eliminado correctamente",
                Success = true,
                Data = true
            };
            return response;
        }
    }
}
