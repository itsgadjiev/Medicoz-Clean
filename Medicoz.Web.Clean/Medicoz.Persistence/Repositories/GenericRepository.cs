using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using BaseEntity = Medicoz.Domain.Common.concrets.BaseEntity;
namespace Medicoz.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{

    protected readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    //public async Task<T> GetLocalizedEntity(string culture, string key)
    //{
    //    return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Culture == culture && x.Key == key);
    //}

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    //Task<List<T>> IGenericRepository<T>.GetAllAsync()
    //{
    //    throw new NotImplementedException();
    //}
}
