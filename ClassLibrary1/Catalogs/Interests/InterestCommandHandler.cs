using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Catalogs.Interests
{
    public class InterestCommandHandler : IRequestHandler<InterestCommand, InterestResponse>
    {
        private readonly IRepository<Interest> _repository;

        public InterestCommandHandler(IRepository<Interest> repository)
        {
            _repository = repository;
        }

        public async Task<InterestResponse> Handle(InterestCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.Create(new Interest { title = request.Title });
            return new InterestResponse { Messsage = "Success" };
        }
    }
}
