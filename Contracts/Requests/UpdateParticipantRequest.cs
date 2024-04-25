using System.Text.Json.Serialization;

namespace Contracts.Requests
{
    public record class UpdateParticipantRequest
    {
        [JsonIgnore] public Guid Id { get; set; }
        public required string Username { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string MiddleName { get; set; }
        public required string Position { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public bool IsActive { get; set; }
        public Guid ContactInformationId { get; set; }
    }
}
