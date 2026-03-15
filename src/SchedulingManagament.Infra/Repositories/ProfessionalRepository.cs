using Microsoft.EntityFrameworkCore;
using SchedulingManagament.Domain.Contracts;
using SchedulingManagament.Domain.Contracts.Repositories;
using SchedulingManagament.Domain.Entities;
using SchedulingManagament.Infra.Data;

namespace SchedulingManagament.Infra.Repositories;

public class ProfessionalRepository :Repository<Professional>, IProfessionalRepository
{
    private readonly SchedulingManagementDbContext _context;

    public ProfessionalRepository(SchedulingManagementDbContext context) : base(context)
        => _context = context;
    
    public async Task<Professional?> GetByIdWithAppointmentsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Professionals
            .AsNoTracking()
            .Include(p => p.Appointments)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<Professional?> GetByIdWithProfessionalServicesAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Professionals
            .AsNoTracking()
            .Include(p => p.ProfessionalServices)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

}
