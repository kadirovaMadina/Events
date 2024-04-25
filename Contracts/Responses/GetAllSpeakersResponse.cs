namespace Contracts.Responses
{
    public record class GetAllSpeakersResponse
    {
        public IEnumerable<SingleSpeakerResponse> Items { get; init; } = Enumerable.Empty<SingleSpeakerResponse>();
    }
}
