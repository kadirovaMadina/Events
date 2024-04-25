namespace Contracts.Responses
{
    public record class SingleParticipantResponse
    {
        public Guid Id { get; init; }
        public required string Username { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string MiddleName { get; init; }
        public required string Position { get; init; }
        public required string Email { get; init; }
        public required string Phone { get; init; }
        public bool IsActive { get; init; }
        public Guid ContactInformationId { get; init; }
    }
}
