using MediatR;
using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.LocalizedStaticEntity.Queries.GetAllStaticEntities
{
    public class GetAllStaticEntitiesQueryHandler : IRequestHandler<GetAllStaticEntitiesQuery, List<StaticEntityListDTO>>
    {
        private readonly ILocalizedStaticEntityRepository _localizedStaticEntityRepository;
        private readonly IStaticDataLocalisationService<Domain.LocalizedStaticEntity> _staticDataLocalisationService;

        public GetAllStaticEntitiesQueryHandler(ILocalizedStaticEntityRepository localizedStaticEntityRepository, IStaticDataLocalisationService<Domain.LocalizedStaticEntity> staticDataLocalisationService)
        {
            _localizedStaticEntityRepository = localizedStaticEntityRepository;
            _staticDataLocalisationService = staticDataLocalisationService;
        }
        public async Task<List<StaticEntityListDTO>> Handle(GetAllStaticEntitiesQuery request, CancellationToken cancellationToken)
        {
            var entities =await _localizedStaticEntityRepository.GetAllAsync();

            var listDtos = entities.Select(e => new StaticEntityListDTO
            {
                Id = e.Id,
                Key = e.Key,
                Value = _staticDataLocalisationService.GetLocalizedValue(e.Key)
            }).ToList();

            return listDtos;
        }
    }
}
