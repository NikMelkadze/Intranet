using Intranet.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Catalogs.Interests
{
    public class CreateInterestCommand : IRequest<CommandResponse>
    {
        public string Title { get; set; }
    }

}
