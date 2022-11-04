using Intranet.Application.Services;
using MediatR;

namespace Intranet.Application.User.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse>
    {
        private readonly IUserService _userService;

        public LoginQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return await _userService.Login(request,cancellationToken);
        }
    }
}
