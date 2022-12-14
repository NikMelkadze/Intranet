using Intranet.Application.Common.Image;
using Intranet.Application.Common.Models;
using Intranet.Application.Services;
using Intranet.Persistance.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Intranet.Application.Employee.UploadEmployeeImage
{
    public class UploadEmployeeImageQueryHandler : IRequestHandler<UploadEmployeeImageQuery, CommandResponse>
    {
        private readonly UserManager<ApplicationUserDTO> _userManager;
        private readonly IUserValidationService _userValidationService;

        public UploadEmployeeImageQueryHandler(UserManager<ApplicationUserDTO> userManager, IUserValidationService userValidationService)
        {
            _userManager = userManager;
            _userValidationService = userValidationService;

        }

        public async Task<CommandResponse> Handle(UploadEmployeeImageQuery request, CancellationToken cancellationToken)
        {
            var id = await _userValidationService.CheckCurrentUserOperationReturnId(request.HttpUser, request.UserId);
            var user = await _userManager.FindByIdAsync(id);
            var image = await ImageConvertor.ImageToByteArr(request.Image, cancellationToken);
            try
            {
                user.Image = image;
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
