using Intranet.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Employee.Commands.DeleteEmployeeInterest
{
    public class DeleteEmployeeInterestQuery : IRequest<CommandResponse>
    {
        public int UserId { get; set; }
        public int InterestId { get; set; }
        public HttpContext HttpUser { get; set; }

    }
    public class DeleteEmployeeInterestRequest
    {
        public int InterestId { get; set; }
    }
}
