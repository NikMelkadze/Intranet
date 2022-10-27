using Intranet.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Employee.AddEmployeeInterests
{
    public class AddEmployeeInterestCommand : IRequest<CommandResponse>
    {
        public int UserId { get; set; }
        public int InterestId { get; set; }
        public HttpContext HttpUser { get; set; }
    }
    public class AddEmployeeInterestRequest : IRequest<CommandResponse>
    {
        public int InterestId { get; set; }
    }
}
