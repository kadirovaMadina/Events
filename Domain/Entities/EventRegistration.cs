using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class EventRegistration : BaseEntity
{
    public DateOnly RegistrationDate { get; set; }
    public bool Status { get; set; } 

    public Guid EventId { get; set; }
    public Guid ParticipantId { get; set; }
    
    public Event? Event { get; set; }
    public Participant? Participant { get; set; }
}