namespace Contracts.Requests
{
    public record class CreateContactInformationRequest
    {
        public string? Phone { get; init; }
        public string? Email { get; init; }
        public string? Telegram { get; init; }
        public string? Instagram { get; init; }
        public string? Facebook { get; init; }
    }
}
