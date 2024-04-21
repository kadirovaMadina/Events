using Domain.Common.BaseEntities;

namespace Domain.Entities
{
    public class EventOrganizer : BaseEntity
    {
        public string? Description { get; set; }

        public Guid EventId { get; set; }
        public Guid OrganizerId { get; set; }

        public Event? Event { get; set; }
        public Organizer? Organizer { get; set; }
    }
}
