namespace Contracts.Requests
{
    public record class CreateSpeakerRequest
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public bool IsActive { get; init; }
        public Guid ContactInformationId { get; init; }
    }
}
