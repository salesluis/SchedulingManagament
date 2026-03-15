using SchedulingManagament.Domain.Entities;

namespace SchedulingManagament.Domain.Contracts.Repositories;


public interface IClientRepository
{
    Task<Client?> GetByIdWithAppointmentsAsync(Guid id, CancellationToken cancellationToken = default);
}
