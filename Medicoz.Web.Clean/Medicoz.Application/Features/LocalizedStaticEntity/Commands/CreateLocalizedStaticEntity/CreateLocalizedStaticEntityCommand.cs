using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.LocalizedStaticEntity.Commands.CreateLocalizedStaticEntity
{
    public class CreateLocalizedStaticEntityCommand : IRequest<Unit>
    {
        public string Key { get; set; }
        public string AzValue { get; set; }
        public string EnValue { get; set; }
    }
}
