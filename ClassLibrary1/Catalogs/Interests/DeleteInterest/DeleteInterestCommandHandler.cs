using Intranet.Application.Common.Models;
using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Catalogs.Interests.DeleteInterest
{
    public class DeleteInterestCommandHandler : IRequestHandler<DeleteInterestCommand, CommandResponse>
    {
        private readonly IRepository<Interest> _repository;

        public DeleteInterestCommandHandler(IRepository<Interest> repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> Handle(DeleteInterestCommand request, CancellationToken cancellationToken)
        {

            try
            {
                await _repository.DeleteById(request.Id);

            }
            catch (Exception ex)
            {

                return new CommandResponse { Messsage = "Failed" };
            }

            return new CommandResponse { Messsage = "Success" };
        }
    }
}
