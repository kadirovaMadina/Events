namespace Contracts.Responses
{
    public record class SingleEventOrganizerResponse
    {
        public Guid Id { get; init; }
        public string? Description { get; init; }
        public Guid EventId { get; init; }
        public Guid OrganizerId { get; init; }
    }
}
