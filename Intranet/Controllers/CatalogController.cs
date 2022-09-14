using Intranet.Application.Catalogs.Interests;
using Intranet.Application.Catalogs.Interests.DeleteInterest;
using Intranet.Application.Catalogs.Interests.GetInterests;
using Intranet.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intranet.Controllers
{
    [Route("/Catalog")]
    public class CatalogController : ApiControllerBase
    {
        public CatalogController(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost("Interest")]
        public async Task<CommandResponse> CreateInterest([FromBody] CreateInterestCommand model)
        {
            return await Mediator.Send(new CreateInterestCommand { Title = model.Title });
        }

        [HttpGet("Interest")]
        public async Task<IterestsVM> GetInterest()
        {
            return await Mediator.Send(new GetInterestsQuery { });
        }

        [HttpDelete("Interest{Id}")]
        public async Task<CommandResponse> DeleteInterest(int Id)
        {
            return await Mediator.Send(new DeleteInterestCommand { Id = Id });
        }
    }
}
