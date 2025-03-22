using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;


namespace Ecommerce.Application.Queries
{
    public record LoginUserQuery(string Email, string Password) : IRequest<ResponseFormat<string>>;

    public class LoginUserQueryHandler(IUserRepository userRepository)
        : IRequestHandler<LoginUserQuery, ResponseFormat<string>>
    {
        public async Task<ResponseFormat<string>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.LoginAsync(request.Email, request.Password);
        }
    }
}
