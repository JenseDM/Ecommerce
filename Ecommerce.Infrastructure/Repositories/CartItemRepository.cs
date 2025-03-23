

using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using Ecommerce.Core.Models;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly AppDbContext _context;

        public CartItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CartItemEntity> GetCartItemByIdAsync(Guid cartItemId)
        {
            if (_context.CartItems == null)
            {
                throw new InvalidOperationException("No exista la tabla CartItems");
            }
            var result = await _context.CartItems.FirstOrDefaultAsync(x => x.Id == cartItemId);
            if (result == null)
            {
                throw new InvalidOperationException("No existe el item en el carrito");
            }
            return result;
        }

        public async Task<ResponseFormat<CartItemEntity>> AddCartItemAsync(CartItemEntity cartItem)
        {
            if (_context.CartItems == null || _context.Products == null)
            {
                throw new InvalidOperationException("No exista la tabla CartItems");
            }

            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == cartItem.ProductId);
            if (product == null)
            {
                throw new InvalidOperationException("No existe el producto");
            }

            cartItem.Price = product.Price * cartItem.Quantity;

            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();

            var response =  new ResponseFormat<CartItemEntity>
            {
                Data = cartItem,
                Message = "Item agregado al carrito",
                Success = true
            };

            return response;
        }

        public async Task<ResponseFormat<CartItemEntity>> UpdateCartItemAsync(CartItemEntity cartItem)
        {
            if (_context.CartItems == null || _context.Products == null)
            {
                throw new InvalidOperationException("No exista la tabla CartItems");
            }

            var item = await _context.CartItems.FirstOrDefaultAsync(x => x.Id == cartItem.Id);
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == cartItem.ProductId);

            if (item == null || product == null)
            {
                throw new InvalidOperationException("No existe el item en el carrito");
            }

            item.Quantity = cartItem.Quantity;
            item.Price = product.Price * item.Quantity;

            _context.CartItems.Update(item);
            await _context.SaveChangesAsync();

            var response = new ResponseFormat<CartItemEntity>
            {
                Data = item,
                Message = "Item actualizado",
                Success = true
            };
            return response;
        }

        public async Task<ResponseFormat<bool>> DeleteCartItemAsync(Guid cartItemId)
        {
            if (_context.CartItems == null)
            {
                throw new InvalidOperationException("No existe la tabla CartItems");
            }
            var item = await _context.CartItems.FirstOrDefaultAsync(x => x.Id == cartItemId);
            if (item == null)
            {
                throw new InvalidOperationException("No existe el item en el carrito");
            }
            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();

            var response = new ResponseFormat<bool>
            {
                Data = true,
                Message = "Item eliminado",
                Success = true
            };

            return response;
        }

        public async Task<IEnumerable<CartItemDetailsModel>> GetCartItemsDetailAsync(Guid cartId)
        {
            if (_context.CartItems == null || _context.Products == null)
            {
                throw new InvalidOperationException("No exista la tabla CartItems");
            }
            var result = await _context.CartItems
                .Where(x => x.CartId == cartId)
                .Join(_context.Products,
                    cartItem => cartItem.ProductId,
                    product => product.Id,
                    (cartItem, product) => new CartItemDetailsModel
                    {
                        CartItemId = cartItem.Id,
                        ProductId = product.Id,
                        Quantity = cartItem.Quantity,
                        Price = cartItem.Price,
                        ProductName = product.Name,
                        ProductDescription = product.Description,
                        ProductImageUrl = product.ImageUrl
                    })
                .ToListAsync();
            if (result == null)
            {
                throw new InvalidOperationException("No existen items en el carrito");
            }
            return result;
        }
    }
}
