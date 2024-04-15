using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class EventRegistration : BaseEntity
{
    public Guid EventId { get; set; }
    public Guid ParticipantId { get; set; }
    public DateOnly RegistrationDate { get; set; }

    public Event? Event { get; set; }
    public Participant? Participant { get; set; }
}