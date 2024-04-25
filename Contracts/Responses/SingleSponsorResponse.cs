namespace Contracts.Responses
{
    public record class SingleSponsorResponse
    {
        public Guid Id { get; init; }
        public required string CompanyName { get; init; }
        public required string Description { get; init; }
        public bool IsActive { get; init; }
        public Guid ContactInformationId { get; init; }
    }
}
