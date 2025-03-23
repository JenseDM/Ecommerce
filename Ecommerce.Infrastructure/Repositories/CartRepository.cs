

using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CartEntity> GetCartByUserIdAsync(Guid userId)
        {
            if (_context.Carts == null)
            {
                throw new InvalidOperationException("No se ha encontrado ningún carrito en la base de datos");
            }

            var result =  await _context.Carts.FirstOrDefaultAsync(x => x.UserId == userId);

            if (result == null)
            {
                throw new InvalidOperationException("El carrito no existe");
            }

            return result;
        }

        public async Task<CartEntity> GetCartByIdAsync(Guid cartId)
        {
            if (_context.Carts == null)
            {
                throw new InvalidOperationException("No se ha encontrado ningún carrito en la base de datos");
            }
            var result = await _context.Carts.FirstOrDefaultAsync(x => x.Id == cartId);
            if (result == null)
            {
                throw new InvalidOperationException("El carrito no existe");
            }
            return result;
        }

        public async Task<ResponseFormat<CartEntity>> AddCartAsync(Guid userId)
        {
            if (_context.Carts == null)
            {
                throw new InvalidOperationException("No se ha encontrado ningún carrito en la base de datos");
            }

            var cart = new CartEntity
            {
                Id = Guid.NewGuid(),
                UserId = userId
            };

            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            var response =  new ResponseFormat<CartEntity>
            {
                Data = cart,
                Message = "Carrito creado correctamente",
                Success = true
            };

            return response;
        }
    }
}
