namespace Contracts.Responses
{
    public record class SingleEventSponsorResponse
    {
        public Guid Id { get; init; }
        public string? Description { get; init; }
        public Guid EventId { get; init; }
        public Guid SponsorId { get; init; }
    }
}
