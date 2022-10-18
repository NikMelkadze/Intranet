using Intranet.Application.Common.Models;
using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using MediatR;
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
        public AddEmployeeInterestCommandHandler(IRepository<EmployeeInterest> repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> Handle(AddEmployeeInterestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.Create(new EmployeeInterest { InterestId = request.InterestId, EmployeeId = request.UserId });

            }
            catch (Exception ex)
            {

                return new CommandResponse { Messsage = "Failed" };

            }
            return new CommandResponse { Messsage = "Success" };
        }
    }
}
