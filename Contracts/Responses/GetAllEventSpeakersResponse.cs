namespace Contracts.Responses
{
    public record class GetAllEventSpeakersResponse
    {
        public IEnumerable<SingleEventSpeakerResponse> Items { get; init; } = Enumerable.Empty<SingleEventSpeakerResponse>();
    }
}
