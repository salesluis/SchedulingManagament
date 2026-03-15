using Microsoft.EntityFrameworkCore;
using SchedulingManagament.Domain.Contracts;
using SchedulingManagament.Domain.Contracts.Repositories;
using SchedulingManagament.Domain.Entities;
using SchedulingManagament.Infra.Data;

namespace SchedulingManagament.Infra.Repositories;

public class ClientRepository : Repository<Client>, IClientRepository
{
    private readonly SchedulingManagementDbContext _context;

    public ClientRepository(SchedulingManagementDbContext context) : 
        base(context)
        => _context = context;
    
    public async Task<Client?> GetByIdWithAppointmentsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Clients
            .AsNoTracking()
            .Include(c => c.Appointments)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}
