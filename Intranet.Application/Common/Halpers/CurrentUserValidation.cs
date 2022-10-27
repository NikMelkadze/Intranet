using Intranet.Infrastructure.Middlewares;
using Intranet.Persistance.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Common.Halpers
{
    public class CurrentUserValidation
    {

        public static void CheckCurrentUser(HttpContext currentUserContext, ApplicationUserDTO user)
        {
            var currentUser = currentUserContext.User.Claims.First().Value;
            if (user?.Email != currentUser)
            {
                throw new AppException("Wrong UserId");
            }
        }
    }
}
