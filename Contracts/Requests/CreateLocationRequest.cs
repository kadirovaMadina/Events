namespace Contracts.Requests
{
    public record class CreateLocationRequest
    {
        public required string Name { get; init; }
        public required string Longitude { get; init; }
        public required string Latitude { get; init; }
        public bool IsActive { get; init; }
    }
}
