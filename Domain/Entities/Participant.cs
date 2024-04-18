using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class Participant : BaseEntity
{
    public required string Username { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string MiddleName { get; set; }
    public required string Position { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public bool IsActive { get; set; }

    public Guid ContactInformationId { get; set; }
    public ContactInformation? ContactInformation { get; set; }

    public virtual ICollection<EventRegistration>? EventRegistrations { get; set; }
    public virtual ICollection<Feedback>? Feedbacks { get; set; }
}