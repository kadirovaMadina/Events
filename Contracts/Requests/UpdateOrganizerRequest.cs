using System.Text.Json.Serialization;

namespace Contracts.Requests
{
    public record class UpdateOrganizerRequest
    {
        [JsonIgnore] public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public bool IsActive { get; set; }
        public Guid ContactInformationId { get; set; }
    }
}
