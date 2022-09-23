using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Persistance.Models
{
    public class DepartmentHead
    {
        public int Id { get; set; }
        public ApplicationUserDTO User { get; set; }
        public int MyProperty { get; set; }
        public int UserID { get; set; }
        public DepartmentDTO Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
