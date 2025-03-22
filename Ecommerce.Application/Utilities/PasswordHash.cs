using Ecommerce.Core.Interfaces;


namespace Ecommerce.Application.Utilities
{
    public class PasswordHash : IPasswordHash
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
