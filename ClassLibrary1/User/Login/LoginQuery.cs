using MediatR;

namespace Intranet.Application.User.Login
{
    public class LoginQuery : IRequest<LoginResponse>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class LoginResponse
    {
        public string? Status { get; set; }
        public string? Token { get; set; }
        public DateTime TokenExpiration { get; set; }
    }
}