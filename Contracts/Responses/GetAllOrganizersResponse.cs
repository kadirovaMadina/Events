namespace Contracts.Responses
{
    public record class GetAllOrganizersResponse
    {
        public IEnumerable<SingleOrganizerResponse> Items { get; init; } = Enumerable.Empty<SingleOrganizerResponse>();
    }
}
