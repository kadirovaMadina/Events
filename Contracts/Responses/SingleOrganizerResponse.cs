namespace Contracts.Responses
{
    public record class SingleOrganizerResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public bool IsActive { get; init; }
        public Guid ContactInformationId { get; init; }
    }
}
