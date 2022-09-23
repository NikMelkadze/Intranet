using Intranet.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Catalogs.Departments.CreateDepartment
{
    public class CreateDepartmentCommand :IRequest<CommandResponse>
    {
        public string Name { get; set; }
    }
}
