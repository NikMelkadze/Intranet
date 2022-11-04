using Intranet.Infrastructure.Middlewares;
using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Services
{
    public class UserValidationService : IUserValidationService
    {
        private readonly IRepository<ApplicationUserDTO> _userService;
        private readonly UserManager<ApplicationUserDTO> _userManager;
        public UserValidationService(IRepository<ApplicationUserDTO> userService)
        {
            _userService = userService;
        }

        public async Task CheckCurrentUserOperation(HttpContext currentUserContext, int userId)
        {
            var user = await _userService.GetById(userId);
            var currentUser = currentUserContext.User.Claims.First().Value;
            if (user?.Email != currentUser)
            {
                throw new AppException("Wrong UserId");
            }
        }

        public async Task<string> CheckCurrentUserOperationReturnId(HttpContext currentUserContext, int userId)
        {
            var user = await _userService.GetById(userId);
            var currentUser = currentUserContext.User.Claims.First().Value;
            if (user?.Email != currentUser)
            {
                throw new AppException("Wrong UserId");
            }
            return user.Id;
        }
    }
}
