namespace Contracts.Responses
{
    public record class SingleSpeakerResponse
    {
        public Guid Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public bool IsActive { get; init; }
        public Guid ContactInformationId { get; init; }
    }
}
