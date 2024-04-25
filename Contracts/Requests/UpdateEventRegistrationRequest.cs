using System.Text.Json.Serialization;

namespace Contracts.Requests
{
    public record class UpdateEventRegistrationRequest
    {
        [JsonIgnore] public Guid Id { get; set; }
        public DateOnly RegistrationDate { get; set; }
        public bool Status { get; set; }
        public Guid EventId { get; set; }
        public Guid ParticipantId { get; set; }
    }
}
