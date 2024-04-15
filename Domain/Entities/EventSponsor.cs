using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class EventSponsor : BaseEntity
{
    public Guid EventId { get; set; }
    public Guid SpeakerId { get; set; }
    public string? Description { get; set; }
    public Event? Event { get; set; }
    public Sponsor? Sponsor { get; set; }
}