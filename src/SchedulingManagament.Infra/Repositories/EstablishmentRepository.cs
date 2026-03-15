using SchedulingManagament.Domain.Contracts.Repositories;
using SchedulingManagament.Domain.Entities;
using SchedulingManagament.Infra.Data;

namespace SchedulingManagament.Infra.Repositories;

public class EstablishmentRepository :Repository<Establishment>, IEstablishmentRepository
{
    private readonly SchedulingManagementDbContext _context;

    public EstablishmentRepository(SchedulingManagementDbContext context) :
        base(context)
        => _context = context;
}
