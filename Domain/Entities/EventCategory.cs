using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class EventCategory : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}