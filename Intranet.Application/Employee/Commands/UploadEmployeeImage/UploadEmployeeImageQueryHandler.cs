using Intranet.Application.Common.Halpers;
using Intranet.Application.Common.Models;
using Intranet.Infrastructure.Middlewares;
using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using MediatR;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Employee.UploadEmployeeImage
{
    public class UploadEmployeeImageQueryHandler : IRequestHandler<UploadEmployeeImageQuery, CommandResponse>
    {
        private readonly UserManager<ApplicationUserDTO> _userManager;
        private readonly IRepository<ApplicationUserDTO> _userService;

        public UploadEmployeeImageQueryHandler(UserManager<ApplicationUserDTO> userManager, IRepository<ApplicationUserDTO> userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        public async Task<CommandResponse> Handle(UploadEmployeeImageQuery request, CancellationToken cancellationToken)
        {
            var userbyUserId = await _userService.GetById(request.UserId);
            CurrentUserValidation.CheckCurrentUser(request.HttpUser, userbyUserId);
            var user = await _userManager.FindByIdAsync(userbyUserId.Id);

            try
            {
                using var dataStream = new MemoryStream();
                await request.Image.CopyToAsync(dataStream);
                byte[] imageBytes = dataStream.ToArray();
                user.Image = imageBytes;
                await _userManager.UpdateAsync(user);
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong");
            }

            return new CommandResponse
            {
                Messsage = "Success"
            };
        }
    }
}
