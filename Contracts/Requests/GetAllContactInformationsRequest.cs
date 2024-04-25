using Domain.Common.BaseEntities;
using Domain.Entities;

namespace Contracts.Requests
{
    public record class GetAllContactInformationsRequest
    {
        public IEnumerable<ContactInformation> Items { get; init; } = Enumerable.Empty<ContactInformation>();
    }
}
