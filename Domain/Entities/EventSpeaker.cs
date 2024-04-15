using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class EventSpeaker : BaseEntity
{
    public Guid EventId { get; set; }
    public Guid SpeakerId { get; set; }
    public Event? Event { get; set; }
    public Speaker? Speaker { get; set; }
}