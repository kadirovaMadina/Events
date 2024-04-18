using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class Event : BaseEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Guid LocationId { get; set; }
    public Guid EventCategoryId { get; set; }
    public Location? Location { get; set; }
    public EventCategory? EventCategory { get; set; }

    public virtual ICollection<EventRegistration>? EventRegistrations { get; set; }
    public virtual ICollection<EventSponsor>? EventSponsors { get; set; }
    public virtual ICollection<EventSpeaker>? EventSpeakers { get; set; }
    public virtual ICollection<Participant>? Participants { get; set; }
    public virtual ICollection<Feedback>? Feedbacks { get; set; }
}