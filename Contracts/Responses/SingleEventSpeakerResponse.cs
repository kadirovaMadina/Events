namespace Contracts.Responses
{
    public record class SingleEventSpeakerResponse
    {
        public Guid Id { get; init; }
        public Guid EventId { get; init; }
        public Guid SpeakerId { get; init; }
    }
}
