namespace Contracts.Responses
{
    public record class GetAllLocationsResponse
    {
        public IEnumerable<SingleLocationResponse> Items { get; init; } = Enumerable.Empty<SingleLocationResponse>();
    }
}
