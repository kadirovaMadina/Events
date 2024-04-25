namespace Contracts.Requests
{
    public record class CreateEventOrganizerRequest
    {
        public string? Description { get; init; }
        public Guid EventId { get; init; }
        public Guid OrganizerId { get; init; }
    }
}
