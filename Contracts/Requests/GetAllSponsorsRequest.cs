using Domain.Entities;

namespace Contracts.Requests
{
    public record class GetAllSponsorsRequest
    {
        public IEnumerable<Sponsor> Items { get; init; } = Enumerable.Empty<Sponsor>();
    }
}
