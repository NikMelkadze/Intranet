using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Intranet.Application.User.Registration
{
    public class RegisterQuery : IRequest<RegisterResponse>
    {

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        public UserRoles UserRole { get; set; }
    }

    public class RegisterResponse
    {
        public string? Message { get; set; }
    }
}
