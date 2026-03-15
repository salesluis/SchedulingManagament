using Microsoft.EntityFrameworkCore;
using SchedulingManagament.Domain.Contracts;
using SchedulingManagament.Domain.Contracts.Repositories;
using SchedulingManagament.Domain.Entities;
using SchedulingManagament.Infra.Data;

namespace SchedulingManagament.Infra.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly SchedulingManagementDbContext _context;

    public ServiceRepository(SchedulingManagementDbContext context)
    {
        _context = context;
    }
}
