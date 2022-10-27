using Intranet.Application.Common.Models;
using MediatR;
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
    }
}
