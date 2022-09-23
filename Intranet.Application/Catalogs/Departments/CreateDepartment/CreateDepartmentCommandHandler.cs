using Intranet.Application.Common.Models;
using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Catalogs.Departments.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, CommandResponse>
    {
        private readonly IRepository<DepartmentDTO> _repository;

        public CreateDepartmentCommandHandler(IRepository<DepartmentDTO> repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.Create(new DepartmentDTO { Name = request.Name });
            }
            catch (Exception ex)
            {
                return new CommandResponse { Messsage = "Failed" };
            }
            return new CommandResponse { Messsage = "Success" };
        }
    }
}
