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
        private readonly ILocalizationService<Domain.LocalizedStaticEntity> _localizationService;

        public GetAllStaticEntitiesQueryHandler(ILocalizedStaticEntityRepository localizedStaticEntityRepository,ILocalizationService<Domain.LocalizedStaticEntity> localizationService)
        {
            _localizedStaticEntityRepository = localizedStaticEntityRepository;
            _localizationService = localizationService;
        }
        public async Task<List<StaticEntityListDTO>> Handle(GetAllStaticEntitiesQuery request, CancellationToken cancellationToken)
        {
            var entities =await _localizedStaticEntityRepository.GetAllAsync();

            var listDtos = entities.Select(e => new StaticEntityListDTO
            {
                Id = e.Id,
                Key = e.Key,
                Value = _localizationService.GetLocalizedValue()
            }).ToList();
        }
    }
}
