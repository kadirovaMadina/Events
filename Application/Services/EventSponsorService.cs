using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class EventSponsorService : IBaseService<EventSponsor>
    {
        private readonly IBaseRepository<EventSponsor> _eventSponsorRepository;

        public EventSponsorService(IBaseRepository<EventSponsor> eventSponsorRepository)
        {
            _eventSponsorRepository = eventSponsorRepository;
        }
        public async Task<EventSponsor> CreateAsync(EventSponsor eventSponsor, CancellationToken token = default)
        {
            return await _eventSponsorRepository.CreateAsync(eventSponsor, token);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var eventSponsor = await _eventSponsorRepository.GetAsync(id);

            if (eventSponsor == null)
                return false;

            return await _eventSponsorRepository.DeleteAsync(eventSponsor, token);
        }

        public async Task<IEnumerable<EventSponsor>> GetAllAsync(CancellationToken token = default)
        {
            return await _eventSponsorRepository.GetAllAsync(token);
        }

        public async Task<EventSponsor> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _eventSponsorRepository.GetAsync(id, token);
        }

        public async Task<bool> UpdateAsync(EventSponsor eventSponsor, CancellationToken token = default)
        {
            var eventSponsorExist = await _eventSponsorRepository.GetAsync(eventSponsor.Id, token);

            if (eventSponsorExist == null)
            {
                return false;
            }

            return await _eventSponsorRepository.UpdateAsync(eventSponsor, token);
        }
    }
}
