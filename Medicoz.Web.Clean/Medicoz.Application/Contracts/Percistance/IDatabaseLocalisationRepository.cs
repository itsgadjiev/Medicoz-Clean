namespace Medicoz.Application.Contracts.Percistance;

public interface IDatabaseLocalisationRepository<T> : IGenericRepository<T> where T : class
{
    Task<T> GetLocalizedEntity();
    Task<List<T>> GetLocalizedEntities();
}
