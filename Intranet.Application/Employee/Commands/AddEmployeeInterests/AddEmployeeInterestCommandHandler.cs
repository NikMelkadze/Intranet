using Intranet.Application.Common.Models;
using Intranet.Application.Services;
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

namespace Intranet.Application.Employee.AddEmployeeInterests
{
    public class AddEmployeeInterestCommandHandler : IRequestHandler<AddEmployeeInterestCommand, CommandResponse>
    {
        private readonly IRepository<EmployeeInterest> _repository;
        private readonly IUserValidationService _userValidationService;
        public AddEmployeeInterestCommandHandler(IRepository<EmployeeInterest> repository, IUserValidationService userValidationService)
        {
            _repository = repository;
            _userValidationService = userValidationService;
        }

        public async Task<CommandResponse> Handle(AddEmployeeInterestCommand request, CancellationToken cancellationToken)
        {
            await _userValidationService.CheckCurrentUserOperation(request.HttpUser, request.UserId);

            try
            {
                var result = await _repository.Create(new EmployeeInterest { InterestId = request.InterestId, EmployeeId = request.UserId });

            }
            catch (Exception ex)
            {

                throw new AppException(ex.Message);

            }
            return new CommandResponse { Messsage = "Success" };
        }
    }
}
