using Intranet.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Intranet.Application.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeQuery : IRequest<CommandResponse>
    {
        public int UserId { get; set; }
        public UpdateEmployeeQueryModel EmployeeModel { get; set; }
        public HttpContext HttpUser { get; set; }
    }
    public class UpdateEmployeeQueryModel
    {
        public string? PhoneNumber { get; set; }
        public string? ProfileInstagram { get; set; }
        public string? ProfileFacebook { get; set; }
        public string? ProfileLinkedin { get; set; }
        public string? Password { get; set; }
    }
}
