using MediatR;
using Microsoft.AspNetCore.Http;

namespace Intranet.Application.User.Login
{
    public class LoginQuery : IRequest<LoginResponse>
    {
        public HttpContext HttpContext { get; set; }
        public LoginRequest loginData { get; set; }
    }

    public class LoginResponse
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public DateTime TokenExpiration { get; set; }
        public string? Token { get; set; }
        public string ImgUrl { get; set; }

    }
    public class LoginRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}