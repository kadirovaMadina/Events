using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class EventSpeakerService : IBaseService<EventSpeaker>
    {
        private readonly IBaseRepository<EventSpeaker> _eventSpeakerRepository;

        public EventSpeakerService(IBaseRepository<EventSpeaker> eventSpeakerRepository)
        {
            _eventSpeakerRepository = eventSpeakerRepository;
        }
        public async Task<EventSpeaker> CreateAsync(EventSpeaker eventSpeaker, CancellationToken token = default)
        {
            return await _eventSpeakerRepository.CreateAsync(eventSpeaker, token);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var eventSpeaker = await _eventSpeakerRepository.GetAsync(id);

            if (eventSpeaker == null)
                return false;

            return await _eventSpeakerRepository.DeleteAsync(eventSpeaker, token);
        }

        public async Task<IEnumerable<EventSpeaker>> GetAllAsync(CancellationToken token = default)
        {
            return await _eventSpeakerRepository.GetAllAsync(token);
        }

        public async Task<EventSpeaker> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _eventSpeakerRepository.GetAsync(id, token);
        }

        public async Task<bool> UpdateAsync(EventSpeaker eventSpeaker, CancellationToken token = default)
        {
            var eventSpeakerExist = await _eventSpeakerRepository.GetAsync(eventSpeaker.Id, token);

            if (eventSpeakerExist == null)
            {
                return false;
            }

            return await _eventSpeakerRepository.UpdateAsync(eventSpeaker, token);
        }
    }
}
