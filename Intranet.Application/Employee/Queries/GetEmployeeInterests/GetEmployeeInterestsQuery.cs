using Intranet.Persistance.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Employee.GetEmployeeInterests
{
    public class GetEmployeeInterestsQuery : IRequest<GetEmployeeInterestsVM>
    {
        public int UserId { get; set; }
    }

    public class GetEmployeeInterestsVM
    {
        public List<GetEmployeeInterests> EmployeeInterests { get; set; }
    }
    public class GetEmployeeInterests
    {
        public int InterestId { get; set; }
        public string Title { get; set; }
    }
}
