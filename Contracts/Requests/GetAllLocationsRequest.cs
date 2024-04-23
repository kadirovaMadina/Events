using Domain.Entities;

namespace Contracts.Requests
{
    public record class GetAllLocationsRequest
    {
        public IEnumerable<Location> Items { get; init; } = Enumerable.Empty<Location>();
    }
}
