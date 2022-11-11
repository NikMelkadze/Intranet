using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intranet.Persistance.Models
{
    public class ApplicationUserDTO : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DepartmentDTO Department { get; set; }
        public int DepartmentId { get; set; }
        public string? ProfileInstagram { get; set; }
        public string? ProfileFacebook { get; set; }
        public string? ProfileLinkedin { get; set; }
        public byte[]? Image { get; set; }
        public int Sex { get; set; }

        public ICollection<EmployeeInterest> EmployeeInterest { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

    }
}
