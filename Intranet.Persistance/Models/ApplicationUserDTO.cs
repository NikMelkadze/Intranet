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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

    }
}
