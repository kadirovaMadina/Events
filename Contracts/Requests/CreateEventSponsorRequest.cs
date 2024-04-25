namespace Contracts.Requests
{
    public record class CreateEventSponsorRequest
    {
        public string? Description { get; init; }
        public Guid EventId { get; init; }
        public Guid SponsorId { get; init; }
    }
}
