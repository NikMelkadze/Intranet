using MediatR;

namespace Intranet.Application.User.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse>
    {
        public Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return  Task.FromResult(new LoginResponse { Message = "Success", Status = "200" });
        }
    }
}
