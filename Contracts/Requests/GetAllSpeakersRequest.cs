using Domain.Entities;

namespace Contracts.Requests
{
    public record class GetAllSpeakersRequest
    {
        public IEnumerable<Speaker> Items { get; init; } = Enumerable.Empty<Speaker>();
    }
}
