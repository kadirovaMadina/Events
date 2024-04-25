using System.Text.Json.Serialization;

namespace Contracts.Requests
{
    public record class UpdateEventSponsorRequest
    {
        [JsonIgnore] public Guid Id { get; set; }
        public string? Description { get; set; }
        public Guid EventId { get; set; }
        public Guid SponsorId { get; set; }
    }
}
