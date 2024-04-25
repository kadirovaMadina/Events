using Domain.Entities;

namespace Contracts.Requests
{
    public record class GetAllEventSponsorsRequest
    {
        public IEnumerable<EventSponsor> Items { get; init; } = Enumerable.Empty<EventSponsor>();
    }
}
