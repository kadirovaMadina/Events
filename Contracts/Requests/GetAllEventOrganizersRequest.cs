using Domain.Entities;

namespace Contracts.Requests
{
    public record class GetAllEventOrganizersRequest
    {
        public IEnumerable<EventOrganizer> Items { get; init; } = Enumerable.Empty<EventOrganizer>();
    }
}
