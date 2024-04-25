namespace Contracts.Responses
{
    public record class GetAllContactInformationsResponse
    {
        public IEnumerable<SingleContactInformationResponse> Items { get; init; } = Enumerable.Empty<SingleContactInformationResponse>();
    }
}
