using Microsoft.EntityFrameworkCore;
using SchedulingManagament.Domain.Abstractions;
using SchedulingManagament.Domain.Contracts.Repositories;

namespace SchedulingManagament.Infra.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly DbContext _context;
    
    public Repository(DbContext context) 
        => _context = context;
    
    public async Task<List<T>> GetAllAsync(CancellationToken ct)
    {
        var entities = await _context
            .Set<T>()
            .AsNoTracking()
            .ToListAsync(ct);
        
        return entities;
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var e = await _context
            .Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id, ct);
        return e;
    }

    public async Task<T> CreateAsync(T entity, CancellationToken ct)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public T UpdateAsync(T entity, CancellationToken ct)
    {
        _context.Set<T>().Update(entity);
        return entity;
    }

    public void DeleteAsync(T entity, CancellationToken ct)
    {
        _context.Remove(entity);
    }
}