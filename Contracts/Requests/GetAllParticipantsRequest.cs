using Domain.Entities;

namespace Contracts.Requests
{
    public record class GetAllParticipantsRequest
    {
        public IEnumerable<Participant> Items { get; init; } = Enumerable.Empty<Participant>();
    }
}
