using Microsoft.EntityFrameworkCore;
using SchedulingManagament.Domain.Contracts;
using SchedulingManagament.Domain.Contracts.Repositories;
using SchedulingManagament.Domain.Entities;
using SchedulingManagament.Infra.Data;

namespace SchedulingManagament.Infra.Repositories;

public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
{
    private readonly SchedulingManagementDbContext _context;

    public AppointmentRepository(SchedulingManagementDbContext context) :
        base(context)
    {
        _context = context;
    }

    public async Task<List<Appointment>> GetByProfessionalIdAsync(Guid professionalId, CancellationToken cancellationToken)
    {
        var a = await _context
            .Appointments
            .AsNoTracking()
            .Where(a => a.ProfessionalId == professionalId)
            .ToListAsync(cancellationToken);

        return a;
    }

    public async Task<List<Appointment>> GetByClientIdAsync(Guid clientId, CancellationToken cancellationToken)
    {
        var a = await _context
            .Appointments
            .AsNoTracking()
            .Where(a => a.ClientId == clientId)
            .ToListAsync(cancellationToken);

        return a;
    }

    public async Task<List<Appointment>> GetByEstablishmentIdAsync(Guid establishmentId,
        CancellationToken cancellationToken = default)
    {
        var a = await _context
            .Appointments
            .AsNoTracking()
            .Where(a => a.EstablishmentId == establishmentId)
            .ToListAsync(cancellationToken);

        return a;
    }
}
