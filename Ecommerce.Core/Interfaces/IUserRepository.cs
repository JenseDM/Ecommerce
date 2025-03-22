using Ecommerce.Core.Formats;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Enums;


namespace Ecommerce.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<ResponseFormat<Guid>> RegisterAsync(UserEntity user);
        Task<ResponseFormat<string>> LoginAsync(string email, string password);
        Task<UserEntity> GetUserByEmailAsync(string email);
        
    }
}
