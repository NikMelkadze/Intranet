using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Persistance.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int EmployeeId { get; set; }
        public string? Department { get; set; }
        public int DepartmentId { get; set; }
        public string? FullName { get; set; }
        public string? CorporatePhone { get; set; }
        public int UserId { get; set; }

    }
}
