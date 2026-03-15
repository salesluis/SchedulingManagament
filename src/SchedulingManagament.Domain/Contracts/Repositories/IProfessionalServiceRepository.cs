using SchedulingManagament.Domain.Entities;

namespace SchedulingManagament.Domain.Contracts.Repositories;

public interface IProfessionalServiceRepository
{
    Task<List<ProfessionalService>> GetByProfessionalIdAsync(Guid professionalId, CancellationToken cancellationToken);
    Task<List<ProfessionalService>> GetByServiceIdAsync(Guid serviceId, CancellationToken cancellationToken);
}
