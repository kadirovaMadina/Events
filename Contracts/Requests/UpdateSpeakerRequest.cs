using System.Text.Json.Serialization;

namespace Contracts.Requests
{
    public record class UpdateSpeakerRequest
    {
        [JsonIgnore] public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public bool IsActive { get; set; }
        public Guid ContactInformationId { get; set; }
    }
}
