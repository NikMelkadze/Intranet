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
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public DateTime TokenExpiration { get; set; }
        public string? Token { get; set; }

    }
}