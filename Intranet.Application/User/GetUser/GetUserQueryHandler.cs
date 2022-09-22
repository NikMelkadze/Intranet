using Intranet.Application.Services;
using MediatR;

namespace Intranet.Application.User.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponse>
    {
        private readonly IUserService _userService;
        public GetUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userService.GetUsers());
        }
    }

}
