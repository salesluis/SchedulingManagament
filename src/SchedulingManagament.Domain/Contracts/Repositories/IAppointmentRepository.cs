using SchedulingManagament.Domain.Entities;

namespace SchedulingManagament.Domain.Contracts.Repositories;

public interface IAppointmentRepository
{
    Task<List<Appointment>> GetByProfessionalIdAsync(Guid professionalId, CancellationToken cancellationToken);
    Task<List<Appointment>> GetByClientIdAsync(Guid clientId, CancellationToken cancellationToken );
    Task<List<Appointment>> GetByEstablishmentIdAsync(Guid establishmentId, CancellationToken cancellationToken );
}
