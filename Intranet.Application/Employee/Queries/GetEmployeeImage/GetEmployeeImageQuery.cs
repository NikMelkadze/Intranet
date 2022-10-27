using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Employee.GetEmployeeImage
{
    public class GetEmployeeImageQuery : IRequest<FileContentResult>
    {
        public int UserId { get; set; }
    }
}
