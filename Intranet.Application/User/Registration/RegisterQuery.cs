using MediatR;
using Microsoft.AspNetCore.Http;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
        public string ProfileInstagram { get; set; }
        public string ProfileFacebook { get; set; }
        public string ProfileLinkedin { get; set; }
        public IFormFile ImageFile { get; set; }
        public UserRoles UserRole { get; set; }
    }

    public class RegisterResponse
    {
        public string? Message { get; set; }
    }
}
