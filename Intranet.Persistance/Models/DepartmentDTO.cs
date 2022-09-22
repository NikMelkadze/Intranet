using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Persistance.Models
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationUserDTO Head { get; set; }
        public string HeadId { get; set; }
    }
}
