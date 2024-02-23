using MediatR;
using Medicoz.Application.Constants;
using Medicoz.Application.Contracts.Percistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.LocalizedStaticEntity.Commands.CreateLocalizedStaticEntity
{
    public class CreateLocalizedStaticEntityCommandHandler : IRequestHandler<CreateLocalizedStaticEntityCommand, Unit>
    {
        private readonly ILocalizedStaticEntityRepository _localizedStaticEntityRepository;

        public CreateLocalizedStaticEntityCommandHandler(ILocalizedStaticEntityRepository localizedStaticEntityRepository)
        {
            _localizedStaticEntityRepository = localizedStaticEntityRepository;
        }
        public async Task<Unit> Handle(CreateLocalizedStaticEntityCommand request, CancellationToken cancellationToken)
        {
            var data = new Domain.LocalizedStaticEntity
            {
                Key = request.Key,
                Value = new Dictionary<string, string>
                {
                     {    LocalizationLanguages.AZ, request.AzValue },
                     { LocalizationLanguages.EN, request.EnValue }
                },
            };

            await _localizedStaticEntityRepository.AddAsync(data);
            await _localizedStaticEntityRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
