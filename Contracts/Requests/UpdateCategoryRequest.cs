using System.Text.Json.Serialization;

namespace Contracts.Requests
{
    public record class UpdateCategoryRequest
    {
        [JsonIgnore] public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
