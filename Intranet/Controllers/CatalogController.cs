using Intranet.Application.Catalogs.Interests;
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
        public async Task<InterestResponse> Interest([FromBody] InterestCommand model)
        {
            return await Mediator.Send(new InterestCommand { Title = model.Title });
        }
    }
}
