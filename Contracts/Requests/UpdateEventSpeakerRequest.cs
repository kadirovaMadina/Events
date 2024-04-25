using System.Text.Json.Serialization;

namespace Contracts.Requests
{
    public record class UpdateEventSpeakerRequest
    {
        [JsonIgnore] public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid SpeakerId { get; set; }
    }
}
