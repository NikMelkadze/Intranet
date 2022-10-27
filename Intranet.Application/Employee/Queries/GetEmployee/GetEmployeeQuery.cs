using Intranet.Persistance.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Employee.GetEmployee
{
    public class GetEmployeeQuery : IRequest<GetEmployeeResponse>
    {
        public int Id { get; set; }
    }
    public class GetEmployeeResponse
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public int UserId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; }
        public string ProfileInstagram { get; set; }
        public string ProfileFacebook { get; set; }
        public string ProfileLinkedin { get; set; }

    }
}
