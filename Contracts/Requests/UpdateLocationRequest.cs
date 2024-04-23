using System.Text.Json.Serialization;

namespace Contracts.Requests
{
    public record class UpdateLocationRequest
    {
        [JsonIgnore] public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Longitude { get; set; }
        public required string Latitude { get; set; }
        public bool IsActive { get; set; }
    }
}
