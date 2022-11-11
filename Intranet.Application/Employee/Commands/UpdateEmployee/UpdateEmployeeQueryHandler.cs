using Intranet.Application.Common.Models;
using Intranet.Application.Services;
using Intranet.Persistance.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Intranet.Application.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeQueryHandler : IRequestHandler<UpdateEmployeeQuery, CommandResponse>
    {
        private readonly UserManager<ApplicationUserDTO> _userManager;
        private readonly IUserValidationService _userValidationService;
        public UpdateEmployeeQueryHandler(UserManager<ApplicationUserDTO> userManager, IUserValidationService userValidationService)
        {
            _userManager = userManager;
            _userValidationService = userValidationService;
        }

        public async Task<CommandResponse> Handle(UpdateEmployeeQuery request, CancellationToken cancellationToken)
        {
            var id = await _userValidationService.CheckCurrentUserOperationReturnId(request.HttpUser, request.UserId);
            var user = await _userManager.FindByIdAsync(id);

            if (request.EmployeeModel.Password != null)
            {
                PasswordHasher<ApplicationUserDTO> passwordHasher = new PasswordHasher<ApplicationUserDTO>();
                user.PasswordHash = passwordHasher.HashPassword(user, request.EmployeeModel.Password);
            }
            user.PhoneNumber = request.EmployeeModel.PhoneNumber ?? user.PhoneNumber;
            user.ProfileInstagram = request.EmployeeModel.ProfileInstagram ?? user.ProfileInstagram;
            user.ProfileFacebook = request.EmployeeModel.ProfileFacebook ?? user.ProfileFacebook;
            user.ProfileLinkedin = request.EmployeeModel.ProfileLinkedin ?? user.ProfileLinkedin;

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
