namespace Contracts.Requests
{
    public record class CreateSponsorRequest
    {
        public required string CompanyName { get; init; }
        public required string Description { get; init; }
        public bool IsActive { get; init; }
        public Guid ContactInformationId { get; init; }
    }
}
