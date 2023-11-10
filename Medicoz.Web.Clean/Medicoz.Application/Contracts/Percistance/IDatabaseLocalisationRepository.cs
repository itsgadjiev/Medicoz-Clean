namespace Medicoz.Application.Contracts.Percistance;

public interface IDatabaseLocalisationRepository<T>
{
    Task<T> GetLocalizedEntity( string key);
    Task<List<T>> GetLocalizedEntities( string key);
}
