namespace Contracts.Responses
{
    public record class GetAllEventsResponse
    {
        public IEnumerable<SingleEventResponse> Items { get; init; } = Enumerable.Empty<SingleEventResponse>();
    }
}
