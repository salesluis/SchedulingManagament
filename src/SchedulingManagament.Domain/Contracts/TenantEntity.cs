using System;
using SchedulingManagament.Domain.Abstractions;
using SchedulingManagament.Domain.Entities;

namespace SchedulingManagament.Domain.Abstractions;

public abstract class TenantEntity : BaseEntity
{
    public Guid EstablishmentId { get; set; }
    public Establishment Establishment { get; set; } = null!;

    public void SetEstablishmentId(Guid establishment)
    {
        EstablishmentId = establishment;
    }
}

