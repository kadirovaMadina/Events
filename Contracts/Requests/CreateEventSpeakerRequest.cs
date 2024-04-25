namespace Contracts.Requests
{
    public record class CreateEventSpeakerRequest
    {
        public Guid EventId { get; init; }
        public Guid SpeakerId { get; init; }
    }
}
