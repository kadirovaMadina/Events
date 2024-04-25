namespace Contracts.Responses
{
    public record class SingleContactInformationResponse
    {
        public Guid Id { get; init; }
        public string? Phone { get; init; }
        public string? Email { get; init; }
        public string? Telegram { get; init; }
        public string? Instagram { get; init; }
        public string? Facebook { get; init; }
    }
}
