using Intranet.Application.Common.Models;
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
    public class CreateInterestCommandHandler : IRequestHandler<CreateInterestCommand, CommandResponse>
    {
        private readonly IRepository<InterestDTO> _repository;

        public CreateInterestCommandHandler(IRepository<InterestDTO> repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> Handle(CreateInterestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.Create(new InterestDTO { Title = request.Title });

            }
            catch (Exception ex)
            {

                return new CommandResponse { Messsage = "Failed" };

            }
            return new CommandResponse { Messsage = "Success" };
        }
    }
}
