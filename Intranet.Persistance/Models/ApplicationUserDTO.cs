using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Persistance.Models
{
    public class ApplicationUserDTO : IdentityUser
    {
        public int EmployeeId { get; set; }
        public int DepartmentID { get; set; }
        public DepartmentDTO Department { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
