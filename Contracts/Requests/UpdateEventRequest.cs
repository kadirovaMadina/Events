using System.Text.Json.Serialization;

namespace Contracts.Requests
{
    public record class UpdateEventRequest
    {
        [JsonIgnore] public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid LocationId { get; set; }
        public Guid EventCategoryId { get; set; }
    }
}
