﻿using Intranet.Application.User.GetUser;
using Intranet.Application.User.Login;
using Intranet.Application.User.Registration;
using Intranet.Persistance.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginQuery model)
        {
            return await Mediator.Send(new LoginQuery { Email = model.Email, Password = model.Password });
        }

        [HttpPost("Registration")]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterQuery model)
        {
            return await Mediator.Send(new RegisterQuery
            {
                Email = model.Email,
                Password = model.Password,
                DateOfBirth = model.DateOfBirth,
                DepartmentId = model.DepartmentId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Position = model.Position,
                UserRole = model.UserRole,
                ProfileFacebook = model.ProfileFacebook,
                ProfileInstagram = model.ProfileInstagram,
                ProfileLinkedin = model.ProfileLinkedin,
            });
        }

        [HttpPost("Image")]
        public async Task<ActionResult> UploadImage(IFormFile img, [FromHeader] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            using var dataStream = new MemoryStream();
            await img.CopyToAsync(dataStream);
            byte[] imageBytes = dataStream.ToArray();
            user.Image = imageBytes;
            await _userManager.UpdateAsync(user);
            return Ok();
        }
        [HttpGet("ImageVM")]
        public async Task<ActionResult> GetImage([FromHeader] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var imgcode = user.Image;

            return new FileContentResult(imgcode, "image/jpeg");

        }
    }
}
