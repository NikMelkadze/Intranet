using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intranet.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ApiControllerBase : Controller
    {
        protected readonly IMediator Mediator;

        public ApiControllerBase()
        {

        }

        public ApiControllerBase(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
    }
