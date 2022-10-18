using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Persistance.Models
{
    public class EmployeeInterest
    {
        public int InterestId { get; set; }
        public InterestDTO Interest { get; set; }
        public ApplicationUserDTO Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
