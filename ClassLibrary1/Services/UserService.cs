using Intranet.Application.User.Registration;
using Intranet.Persistance.Models;
using Microsoft.AspNetCore.Identity;

namespace Intranet.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterResponse> Registration(RegisterQuery request)
        {
            var existUser = await _userManager.FindByEmailAsync(request.Email);
            if (existUser != null)
            {
                throw new ApplicationException("User already Exists");

            }

            ApplicationUser user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = _userManager.CreateAsync(user, request.Password);

            if (!result.IsCompletedSuccessfully)
            {
                throw new ApplicationException("Proccess was not copleted");
            }

            return new RegisterResponse
            {
                Message = "Succes"
            };
        }
    }
}
