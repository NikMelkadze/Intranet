using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using Intranet.Persistance.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Catalogs.Departments.GetDepartments
{
    public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, GetDepartmentsResponse>
    {
        private readonly IRepository<DepartmentDTO> _repository;

        public GetDepartmentsQueryHandler(IRepository<DepartmentDTO> repository)
        {
            _repository = repository;
        }

        public async Task<GetDepartmentsResponse> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {

            var departments = await _repository.Get();
            if (departments == null)
            {
                return new GetDepartmentsResponse { };
            }

            var result = new GetDepartmentsResponse
            {
                Departments = departments.Select(x => new DepartmentDTO
                {
                    Id = x.Id,
                    Name = x.Name
                })
            };
            return result;
        }
    }
}
