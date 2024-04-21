using Domain.Entities;

namespace Contracts.Requests
{
    public record class GetAllEventsRequest
    {
        public IEnumerable<Event> Items { get; init; } = Enumerable.Empty<Event>();
    }
}
