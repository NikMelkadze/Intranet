using Intranet.Application.User;
using Intranet.Application.User.GetUser;
using Intranet.Application.User.Login;
using Intranet.Application.User.Registration;
using Intranet.Persistance.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Intranet.Controllers
{
    [Route("/User")]
    public class UserController : ApiControllerBase
    {
        private readonly UserManager<ApplicationUserDTO> _userManager;
        public UserController(IMediator mediator, UserManager<ApplicationUserDTO> userManager) : base(mediator)
        {
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest model)
        {
            return await Mediator.Send(new LoginQuery { loginData = new LoginRequest { Email = model.Email, Password = model.Password }, HttpContext = HttpContext });
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("Registration")]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterQuery model)
        {
            return await Mediator.Send(new RegisterQuery
            {
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                DepartmentId = model.DepartmentId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Position = model.Position,
                UserRole = model.UserRole,
                Sex = model.Sex,
            });
        }
    }
}
