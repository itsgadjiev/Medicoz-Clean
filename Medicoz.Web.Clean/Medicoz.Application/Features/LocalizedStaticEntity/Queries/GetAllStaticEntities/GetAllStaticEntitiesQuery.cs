using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.LocalizedStaticEntity.Queries.GetAllStaticEntities
{
    public class GetAllStaticEntitiesQuery :IRequest<List<StaticEntityListDTO>>
    {
    }
}
