using SchedulingManagament.Domain.Abstractions;

namespace SchedulingManagament.Domain.Entities;
public class Client : TenantEntity
{
    public Guid? UserId { get; private set; }
    public string Name { get; private set; } = null!;
    public string? PhoneNumber { get; private set; }

    public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();

    public Client(Guid establishmentId, string name, string? phoneNumber = null)
    {
        EstablishmentId = establishmentId;
        Name = name;
        PhoneNumber = phoneNumber;
    }

    public void Update(string name, string? phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Touch();
    }
}

