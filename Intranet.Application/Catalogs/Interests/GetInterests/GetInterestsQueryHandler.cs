using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using MediatR;

namespace Intranet.Application.Catalogs.Interests.GetInterests
{
    internal class GetInterestsQueryHandler : IRequestHandler<GetInterestsQuery, IterestsVM>
    {
        private readonly IRepository<Interest> _repository;

        public GetInterestsQueryHandler(IRepository<Interest> repository)
        {
            _repository = repository;
        }

        public async Task<IterestsVM> Handle(GetInterestsQuery request, CancellationToken cancellationToken)
        {

            var result = await _repository.Get();


            var response = new IterestsVM
            {
                Interests = result.Select(x => new Interest
                {
                    Id = x.Id,
                    Title = x.Title
                })
            };
            return response;

        }

    }
}
