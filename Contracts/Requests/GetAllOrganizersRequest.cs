using Domain.Entities;

namespace Contracts.Requests
{
    public record class GetAllOrganizersRequest
    {
        public IEnumerable<Organizer> Items { get; init; } = Enumerable.Empty<Organizer>();
    }
}
