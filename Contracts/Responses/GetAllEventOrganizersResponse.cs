namespace Contracts.Responses
{
    public record class GetAllEventOrganizersResponse
    {
        public IEnumerable<SingleEventOrganizerResponse> Items { get; init; } = Enumerable.Empty<SingleEventOrganizerResponse>();
    }
}
