using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class Speaker : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public bool IsActive { get; set; }
    
    public Guid ContactInformationId { get; set; }
    public ContactInformation? ContactInformation { get; set; }

    public virtual ICollection<EventSpeaker>? EventSpeakers { get; set; }
}