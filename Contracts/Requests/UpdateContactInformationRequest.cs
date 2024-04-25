using System.Text.Json.Serialization;

namespace Contracts.Requests
{
    public record class UpdateContactInformationRequest
    {
        [JsonIgnore] public Guid Id { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Telegram { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
    }
}
