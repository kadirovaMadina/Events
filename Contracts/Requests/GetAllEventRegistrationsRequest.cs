using Domain.Entities;

namespace Contracts.Requests
{
    public record class GetAllEventRegistrationsRequest
    {
        public IEnumerable<EventRegistration> Items { get; init; } = Enumerable.Empty<EventRegistration>();
    }
}
