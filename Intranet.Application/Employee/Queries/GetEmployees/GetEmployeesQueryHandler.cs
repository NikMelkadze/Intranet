using Intranet.Application.Employee.GetEmployee;
using Intranet.Application.Services;
using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace Intranet.Application.User.GetUser
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, GetEmployeesResponse>
    {
        private readonly IRepository<ApplicationUserDTO> _userService;

        public GetEmployeesQueryHandler(IRepository<ApplicationUserDTO> userService)
        {
            _userService = userService;
        }
        public async Task<GetEmployeesResponse> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.Get();
            if (users == null)
            {
                return null;
            }
            var result = new GetEmployeesResponse
            {
                Employees = users.Select(x => new GetEmployeeResponse
                {
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Department = x.Department.Name,
                    UserId = x.UserId,
                    DateOfBirth = x.DateOfBirth,
                    Position = x.Position,
                    ProfileLinkedin = x.ProfileLinkedin,
                    ProfileFacebook = x.ProfileFacebook,
                    ProfileInstagram = x.ProfileInstagram,
                    ImgUrl = $"{request.HttpContext.Request.Host.Value}/Employee/Image/{x.UserId}"

                })
            };
            return result;
        }
    }

}
