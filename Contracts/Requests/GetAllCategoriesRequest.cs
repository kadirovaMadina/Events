using Domain.Entities;

namespace Contracts.Requests
{
    public record class GetAllCategoriesRequest
    {
        public IEnumerable<EventCategory> Items { get; init; } = Enumerable.Empty<EventCategory>();
    }
}
