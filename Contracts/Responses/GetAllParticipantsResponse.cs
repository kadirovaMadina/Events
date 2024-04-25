namespace Contracts.Responses
{
    public record class GetAllParticipantsResponse
    {
        public IEnumerable<SingleParticipantResponse> Items { get; init; } = Enumerable.Empty<SingleParticipantResponse>();

    }
}
