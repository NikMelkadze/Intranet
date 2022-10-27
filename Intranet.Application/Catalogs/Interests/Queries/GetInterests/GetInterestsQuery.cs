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
        public IEnumerable<Iterest> Interests { get; set; }
    }

    public class Iterest
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
