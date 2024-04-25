using System.Text.Json.Serialization;

namespace Contracts.Requests
{
    public record class UpdateSponsorRequest
    {
        [JsonIgnore] public Guid Id { get; set; }
        public required string CompanyName { get; set; }
        public required string Description { get; set; }
        public bool IsActive { get; set; }
        public Guid ContactInformationId { get; set; }
    }
}
