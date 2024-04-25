namespace Contracts.Responses
{
    public record class GetAllSponsorsResponse
    {
        public IEnumerable<SingleSponsorResponse> Items { get; init; } = Enumerable.Empty<SingleSponsorResponse>();
    }
}
