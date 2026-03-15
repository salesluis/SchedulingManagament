using SchedulingManagament.Domain.Abstractions;

namespace SchedulingManagament.Domain.Contracts.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync(CancellationToken ct);
    Task<T?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<T> CreateAsync(T entity, CancellationToken ct);
    T UpdateAsync(T entity, CancellationToken ct);
    void DeleteAsync(T entity, CancellationToken ct);
}