using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using MediatR;

namespace Intranet.Application.Catalogs.Interests.GetInterests
{
    internal class GetInterestsQueryHandler : IRequestHandler<GetInterestsQuery, IterestsVM>
    {
        private readonly IRepository<InterestDTO> _repository;

        public GetInterestsQueryHandler(IRepository<InterestDTO> repository)
        {
            _repository = repository;
        }

        public async Task<IterestsVM> Handle(GetInterestsQuery request, CancellationToken cancellationToken)
        {

            var result = await _repository.Get();

            if (result == null)
            {
                return new IterestsVM { };
            }

            var response = new IterestsVM
            {
                Interests = result.Select(x => new InterestDTO
                {
                    Id = x.Id,
                    Title = x.Title
                })
            };
            return response;

        }

    }
}
