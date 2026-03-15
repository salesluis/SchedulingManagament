namespace SchedulingManagament.Domain.Contracts;

public interface IUnitOfWork
{
    Task CommitAsync();
}