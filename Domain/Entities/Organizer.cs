using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class Organizer : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public bool IsActive { get; set; }

    public Guid ContactInformationId { get; set; }
    public ContactInformation? ContactInformation { get; set; }

    public virtual ICollection<Speaker> Speakers { get; set; }
    
}