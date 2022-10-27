using Intranet.Persistance.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Services
{
    public interface IUserValidationService
    {
        public Task CheckCurrentUserOperation(HttpContext currentUserContext, int userId);
        public Task<string> CheckCurrentUserOperationReturnId(HttpContext currentUserContext, int userId);

    }
}
