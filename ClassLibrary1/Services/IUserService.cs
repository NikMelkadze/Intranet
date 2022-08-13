using Intranet.Application.User.Registration;

namespace Intranet.Application.Services
{
    public interface IUserService
    {
        public Task<RegisterResponse> Registration(RegisterQuery request);
    }
}
