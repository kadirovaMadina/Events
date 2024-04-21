namespace Contracts.Requests
{
    public record class CreateEventRequest
    {
        public required string Title { get; init; }
        public required string Description { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public Guid LocationId { get; init; }
        public Guid EventCategoryId { get; init; }
    }
}
