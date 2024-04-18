using Domain.Entities;

namespace Domain.Common.BaseEntities;

public class ContactInformation : BaseEntity
{
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Telegram { get; set; }
    public string? Instagram { get; set; }
    public string? Facebook { get; set; }

    public virtual ICollection<Organizer>? Organizers { get; set; }
    public virtual ICollection<Participant>? Participants { get; set; }
    public virtual ICollection<Speaker>? Speakers { get; set; }
    public virtual ICollection<Sponsor>? Sponsors { get; set; }

}