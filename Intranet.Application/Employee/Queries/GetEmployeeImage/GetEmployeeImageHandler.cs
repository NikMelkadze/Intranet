using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Employee.GetEmployeeImage
{
    public class GetEmployeeImageHandler : IRequestHandler<GetEmployeeImageQuery, FileContentResult>
    {
        private readonly IRepository<ApplicationUserDTO> _userService;
        public GetEmployeeImageHandler(IRepository<ApplicationUserDTO> userService)
        {
            _userService = userService;
        }

        public async Task<FileContentResult> Handle(GetEmployeeImageQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetById(request.UserId);
            var imgcode = user.Image;

            return new FileContentResult(imgcode, "image/jpeg");
        }
    }
}
