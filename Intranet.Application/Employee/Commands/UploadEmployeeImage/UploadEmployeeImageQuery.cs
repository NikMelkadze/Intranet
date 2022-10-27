using Intranet.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Employee.UploadEmployeeImage
{
    public class UploadEmployeeImageQuery : IRequest<CommandResponse>
    {
        public int UserId { get; set; }
        public HttpContext HttpUser { get; set; }
        public IFormFile Image { get; set; }

    }
}
