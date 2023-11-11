using Medicoz.Domain;

namespace Medicoz.Application.Contracts.Percistance
{
    public interface ISliderRepository : IDatabaseLocalisationRepository<Slider>
    {
        Task<List<Slider>> GetByUniqueCode(string code);
    }
}
