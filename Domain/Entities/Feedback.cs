using Domain.Common.BaseEntities;
using Domain.Enums;

namespace Domain.Entities;

public class Feedback : BaseEntity
{
    public Guid EventId { get; set; }
    public Guid ParticipantId { get; set; }
    public FeedbackGradeEnum Grade { get; set; }
    public string? Comment { get; set; }
    
    public Event? Event { get; set; }
    public Participant? Participant { get; set; }
}