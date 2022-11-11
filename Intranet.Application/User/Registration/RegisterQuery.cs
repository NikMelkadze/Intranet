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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
        public int Sex { get; set; }
        public UserRole UserRole { get; set; }
    }

    public class RegisterResponse
    {
        public string? Message { get; set; }
    }

    public enum UserRole
    {
        Admin,
        User
    }
}
