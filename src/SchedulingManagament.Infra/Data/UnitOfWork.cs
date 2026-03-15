using SchedulingManagament.Domain.Contracts;

namespace SchedulingManagament.Infra.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly SchedulingManagementDbContext _context;
    public UnitOfWork(SchedulingManagementDbContext context) 
        => _context = context;
    
    public Task CommitAsync() =>  _context.SaveChangesAsync();
}