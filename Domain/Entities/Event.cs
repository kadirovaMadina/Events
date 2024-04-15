using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class Event : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid LocationId { get; set; }
    public Guid EventCategoryId { get; set; }
    public Location? Location { get; set; }
    public EventCategory? EventCategory { get; set; }
    
    public ICollection<EventSponsor>? EventSponsors { get; set; }
    public ICollection<EventSpeaker>? EventSpeakers { get; set; }
    public ICollection<Participant>? Participants { get; set; }
    public ICollection<Feedback>? Feedbacks { get; set; }
}