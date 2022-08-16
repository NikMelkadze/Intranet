using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Catalogs.Interests
{
    public class InterestCommand : IRequest<InterestResponse>
    {
        public string Title { get; set; }
    }

    public class InterestResponse
    {
        public string Messsage { get; set; }
    }
}
