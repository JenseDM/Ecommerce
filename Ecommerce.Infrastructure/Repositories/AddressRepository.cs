using Ecommerce.Core.Formats;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class AddressRepository: IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseFormat<AddressEntity>> AddAddressAsync(AddressEntity address, Guid userId)
        {
            if(_context.Addresses == null)
            {
                throw new InvalidOperationException("No existe la tabla Direcciones.");
            }

            address.UserId = userId;
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            var response = new ResponseFormat<AddressEntity>
            {
                Success = true,
                Message = "Dirección agregada correctamente",
                Data = address
            };

            return response;
        }

        public async Task<ResponseFormat<AddressEntity>> UpdateAddressAsync(AddressEntity address)
        {
            if (_context.Addresses == null)
            {
                throw new InvalidOperationException("No existe la tabla Direcciones.");
            }
            var addressToUpdate = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == address.Id);
            if (addressToUpdate == null)
            {
                throw new Exception("Dirección no encontrada");
            }
            addressToUpdate.Address = address.Address;
            addressToUpdate.City = address.City;
            addressToUpdate.Country = address.Country;
            addressToUpdate.PostalCode = address.PostalCode;

            _context.Addresses.Update(addressToUpdate);
            await _context.SaveChangesAsync();

            var response = new ResponseFormat<AddressEntity>
            {
                Success = true,
                Message = "Dirección actualizada correctamente",
                Data = addressToUpdate
            };
            return response;
        }

        public async Task<ResponseFormat<bool>> DeleteAddressAsync(Guid addressId)
        {
            if (_context.Addresses == null)
            {
                throw new InvalidOperationException("No existe la tabla Direcciones.");
            }
            var addressToDelete = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == addressId);
            if (addressToDelete == null)
            {
                throw new Exception("Dirección no encontrada");
            }
            _context.Addresses.Remove(addressToDelete);
            await _context.SaveChangesAsync();
            var response = new ResponseFormat<bool>
            {
                Success = true,
                Message = "Dirección eliminada correctamente",
                Data = true
            };
            return response;
        }

        public async Task<AddressEntity> GetAddressByIdAsync(Guid addressId)
        {
            if (_context.Addresses == null)
            {
                throw new InvalidOperationException("No existe la tabla Direcciones.");
            }
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == addressId);
            if (address == null)
            {
                throw new Exception("Dirección no encontrada");
            }
            return address;
        }

        public async Task<IEnumerable<AddressEntity>> GetAddressesByUserIdAsync(Guid userId)
        {
            if (_context.Addresses == null)
            {
                throw new InvalidOperationException("No existe la tabla Direcciones.");
            }
            var addresses = await _context.Addresses.Where(a => a.UserId == userId).ToListAsync();
            return addresses;
        }
    }
}
