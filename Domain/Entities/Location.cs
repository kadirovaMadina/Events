using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class Location : BaseEntity
{
    public required string Name { get; set; }
    public required string Longitude { get; set; }
    public required string Latitude { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<Event>? Events { get; set; }
}