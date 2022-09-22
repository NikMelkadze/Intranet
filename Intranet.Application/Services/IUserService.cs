using Intranet.Application.User.GetUser;
using Intranet.Application.User.Login;
using Intranet.Application.User.Registration;

namespace Intranet.Application.Services
{
    public interface IUserService
    {
        public Task<RegisterResponse> Registration(RegisterQuery request);
        public Task<LoginResponse> Login(LoginQuery request);
        public GetUserResponse GetUsers();

    }
}
