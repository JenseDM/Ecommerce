using Ecommerce.Core.Entities;

namespace Ecommerce.Application.Utilities
{
    public interface IJwtServiceUtility
    {
        string GenerateToken(UserEntity user);
    }
}