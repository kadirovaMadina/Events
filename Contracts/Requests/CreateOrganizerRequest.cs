namespace Contracts.Requests
{
    public record class CreateOrganizerRequest
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
        public bool IsActive { get; init; }
        public Guid ContactInformationId { get; init; }
    }
}
