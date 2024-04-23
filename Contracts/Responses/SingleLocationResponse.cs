namespace Contracts.Responses
{
    public record class SingleLocationResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Longitude { get; init; }
        public required string Latitude { get; init; }
        public bool IsActive { get; init; }
    }
}
