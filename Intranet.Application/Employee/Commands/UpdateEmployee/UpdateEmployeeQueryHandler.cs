using Intranet.Application.Common.Halpers;
using Intranet.Application.Common.Models;
using Intranet.Infrastructure.Middlewares;
using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeQueryHandler : IRequestHandler<UpdateEmployeeQuery, CommandResponse>
    {
        private readonly UserManager<ApplicationUserDTO> _userManager;
        private readonly IRepository<ApplicationUserDTO> _userService;
        public UpdateEmployeeQueryHandler(UserManager<ApplicationUserDTO> userManager, IRepository<ApplicationUserDTO> userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        public async Task<CommandResponse> Handle(UpdateEmployeeQuery request, CancellationToken cancellationToken)
        {
            var userbyUserId = await _userService.GetById(request.UserId);
            CurrentUserValidation.CheckCurrentUser(request.HttpUser, userbyUserId);
            var user = await _userManager.FindByIdAsync(userbyUserId.Id);

            user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;
            user.ProfileInstagram = request.ProfileInstagram ?? user.ProfileInstagram;
            user.ProfileFacebook = request.ProfileFacebook ?? user.ProfileFacebook;
            user.ProfileLinkedin = request.ProfileLinkedin ?? user.ProfileLinkedin;
            try
            {
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
