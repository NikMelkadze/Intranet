using Intranet.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Catalogs.Interests.DeleteInterest
{
    public class DeleteInterestCommand : IRequest<CommandResponse>
    {
        public int Id { get; set; }
    }

}
