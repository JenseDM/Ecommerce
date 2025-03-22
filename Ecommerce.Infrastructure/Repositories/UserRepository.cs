using Ecommerce.Application.Utilities;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Enums;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly IPasswordHash _passwordHash;
    private readonly IJwtServiceUtility _jwtServiceUtility;

    public UserRepository(AppDbContext context, IPasswordHash passwordHash, IJwtServiceUtility jwtServiceUtility)
    {
        _context = context;
        _passwordHash = passwordHash;
        _jwtServiceUtility = jwtServiceUtility;
    }

    public async Task<ResponseFormat<string>> LoginAsync(string email, string password)
    {
        // Verificar si _context.Users no es nulo
        if (_context.Users == null)
        {
            throw new InvalidOperationException("No existe la tabla Usuarios.");
        }

        // Buscar el usuario por correo
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (user == null || _passwordHash.VerifyPassword(password, user.PasswordHash) == false)
        {
            throw new Exception("Credenciales invalidas"); // Credenciales inválidas
        }

        // Generar token JWT
        var Token = _jwtServiceUtility.GenerateToken(user);

        var response = new ResponseFormat<string>
        {
            Success = true,
            Message = "Usuario autenticado",
            Data = Token
        };
        return response; // Retorna el estado de la consulta, un mensaje y el token JWT
    }

    public async Task<ResponseFormat<Guid>> RegisterAsync(UserEntity user)
    {
        // Verificar si _context.Users no es nulo
        if (_context.Users == null)
        {
            throw new InvalidOperationException("La colección de usuarios no está inicializada.");
        }

        // Verificar si el usuario ya existe
        if (await _context.Users.AnyAsync(u => u.Email == user.Email))
        {
            throw new Exception("El usuario ya existe."); // El correo ya está registrado
        }

        // Asignar valores al usuario
        user.Role = RoleEnum.user; // Asignar un rol por defecto
        user.PasswordHash = _passwordHash.HashPassword(user.PasswordHash); // Encriptar la contraseña

        // Guardar el usuario en la base de datos
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        var response = new ResponseFormat<Guid>
        {
            Success = true,
            Message = "Usuario registrado",
            Data = user.Id
        };

        return response;
    }

    public async Task<UserEntity> GetUserByEmailAsync(string email)
    {
        // Verificar si _context.Users no es nulo
        if (_context.Users == null)
        {
            throw new InvalidOperationException("No existe la tabla Usuarios.");
        }

        // Buscar el usuario por correo
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (user == null)
        {
            throw new Exception("El usuario no existe"); // Usuario no encontrado
        }

        return user;
    }

    public async Task<UserEntity> GetUserByIdAsync(Guid id)
    {
        // Verificar si _context.Users no es nulo
        if (_context.Users == null)
        {
            throw new InvalidOperationException("No existe la tabla Usuarios.");
        }
        // Buscar el usuario por ID
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            throw new Exception("El usuario no existe"); // Usuario no encontrado
        }
        return user;
    }

    public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
    {
        // Verificar si _context.Users no es nulo
        if (_context.Users == null)
        {
            throw new InvalidOperationException("No existe la tabla Usuarios.");
        }
        // Obtener todos los usuarios
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task<ResponseFormat<UserEntity>> UpdateUserBasicAsync(UserEntity user)
    {
        // Verificar si _context.Users no es nulo
        if (_context.Users == null)
        {
            throw new InvalidOperationException("No existe la tabla Usuarios.");
        }
        // Buscar el usuario por ID
        var userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
        if (userToUpdate == null)
        {
            throw new Exception("El usuario no existe"); // Usuario no encontrado
        }
        // Actualizar los datos del usuario
        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;
        userToUpdate.Phone = user.Phone;
        // Guardar los cambios en la base de datos
        _context.Users.Update(userToUpdate);
        await _context.SaveChangesAsync();
        var response = new ResponseFormat<UserEntity>
        {
            Success = true,
            Message = "Usuario actualizado correctamente",
            Data = userToUpdate
        };
        return response;
    }

    public async Task<ResponseFormat<bool>> DeleteUserAsync(Guid id)
    {
        // Verificar si _context.Users no es nulo
        if (_context.Users == null)
        {
            throw new InvalidOperationException("No existe la tabla Usuarios.");
        }
        // Buscar el usuario por ID
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            throw new Exception("El usuario no existe"); // Usuario no encontrado
        }
        
        user.IsActive = false;
        await _context.SaveChangesAsync();
        var response = new ResponseFormat<bool>
        {
            Success = true,
            Message = "Usuario eliminado(Desactivado) correctamente",
            Data = true
        };
        return response;
    }

}