namespace Contracts.Responses
{
    public record class GetAllEventSponsorsResponse
    {
        public IEnumerable<SingleEventSponsorResponse> Items { get; init; } = Enumerable.Empty<SingleEventSponsorResponse>();
    }
}
