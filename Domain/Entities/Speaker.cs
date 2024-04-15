using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class Speaker : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public Guid OrganizerId { get; set; }
    public Organizer? Organizer { get; set; }
    public bool IsActive { get; set; }
}