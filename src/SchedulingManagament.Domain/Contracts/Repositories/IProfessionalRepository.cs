using SchedulingManagament.Domain.Entities;

namespace SchedulingManagament.Domain.Contracts.Repositories;

public interface IProfessionalRepository
{
    Task<Professional?> GetByIdWithAppointmentsAsync(Guid id, CancellationToken cancellationToken);
    Task<Professional?> GetByIdWithProfessionalServicesAsync(Guid id, CancellationToken cancellationToken);
}
