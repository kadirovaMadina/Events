using Domain.Entities;

namespace Contracts.Requests
{
    public record class GetAllEventSpeakersRequest
    {
        public IEnumerable<EventSpeaker> Items { get; init; } = Enumerable.Empty<EventSpeaker>();
    }
}
