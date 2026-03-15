using Microsoft.EntityFrameworkCore;
using SchedulingManagament.Domain.Contracts;
using SchedulingManagament.Domain.Contracts.Repositories;
using SchedulingManagament.Domain.Entities;
using SchedulingManagament.Infra.Data;
using SchedulingManagament.Infra.Repositories;

namespace scheduling_management.Infra.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly SchedulingManagementDbContext _context;

    public UserRepository(SchedulingManagementDbContext context)
        : base(context)
        => _context = context;
}
