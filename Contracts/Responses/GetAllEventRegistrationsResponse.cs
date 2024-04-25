namespace Contracts.Responses
{
    public record class GetAllEventRegistrationsResponse
    {
        public IEnumerable<SingleEventRegistrationResponse> Items { get; init; } = Enumerable.Empty<SingleEventRegistrationResponse>();
    }
}
