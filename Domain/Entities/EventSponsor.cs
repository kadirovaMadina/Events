using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class EventSponsor : BaseEntity
{
    public string? Description { get; set; }

    public Guid EventId { get; set; }
    public Guid SponsorId { get; set; }
    
    public Event? Event { get; set; }
    public Sponsor? Sponsor { get; set; }
}