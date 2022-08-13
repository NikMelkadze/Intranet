using Intranet.Application.Services;
using MediatR;

namespace Intranet.Application.User.Registration
{
    public class RegisterQueryHandler : IRequestHandler<RegisterQuery, RegisterResponse>
    {
        private readonly IUserService _userService;

        public RegisterQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<RegisterResponse> Handle(RegisterQuery request, CancellationToken cancellationToken)
        {

            return await _userService.Registration(request);
        }
    }
}
