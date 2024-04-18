using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class Sponsor : BaseEntity
{
    public required string CompanyName { get; set; }
    public required string Description { get; set; }
    public bool IsActive { get; set; }

    public Guid ContactInformationId { get; set; }
    public ContactInformation? ContactInformation { get; set; }
    
    public virtual ICollection<EventSponsor>? EventSponsors { get; set; }
}