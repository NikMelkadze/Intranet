using Intranet.Persistance.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Catalogs.Interests.GetInterests
{
    public class GetInterestsQuery : IRequest<IterestsVM>
    {

    }
    public class IterestsVM
    {
        public IEnumerable<Interest> Interests { get; set; }
    }

}
