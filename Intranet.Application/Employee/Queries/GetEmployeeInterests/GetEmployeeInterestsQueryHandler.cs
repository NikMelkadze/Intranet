using Intranet.Application.Catalogs.Interests.GetInterests;
using Intranet.Application.Common.Models;
using Intranet.Application.Employee.AddEmployeeInterests;
using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Employee.GetEmployeeInterests
{
    public class GetEmployeeInterestsQueryHandler : IRequestHandler<GetEmployeeInterestsQuery, GetEmployeeInterestsVM>
    {
        private readonly IRepository<EmployeeInterest> _repository;
        public GetEmployeeInterestsQueryHandler(IRepository<EmployeeInterest> repository)
        {
            _repository = repository;
        }

        public async Task<GetEmployeeInterestsVM> Handle(GetEmployeeInterestsQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetByUser(request.UserId);

            if (response == null)
            {
                return new GetEmployeeInterestsVM { };
            }

            var result = new GetEmployeeInterestsVM
            {
                EmployeeInterests = response.Select(x => new GetEmployeeInterests
                {
                    InterestId = x.InterestId,
                    Title = x.Interest.Title,
                }).ToList()
            };
            return result;
        }
    }
}
