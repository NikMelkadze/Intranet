using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Intranet.Persistance.Models
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<ApplicationUserDTO> Users { get; set; }
    }
}
