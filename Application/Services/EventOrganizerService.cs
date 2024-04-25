using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class EventOrganizerService : IBaseService<EventOrganizer>
    {
        private readonly IBaseRepository<EventOrganizer> _eventOrganizerRepository;

        public EventOrganizerService(IBaseRepository<EventOrganizer> eventOrganizerRepository)
        {
            _eventOrganizerRepository = eventOrganizerRepository;
        }
        public async Task<EventOrganizer> CreateAsync(EventOrganizer eventOrganizer, CancellationToken token = default)
        {
            return await _eventOrganizerRepository.CreateAsync(eventOrganizer, token);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var eventOrganizer = await _eventOrganizerRepository.GetAsync(id);

            if (eventOrganizer == null)
                return false;

            return await _eventOrganizerRepository.DeleteAsync(eventOrganizer, token);
        }

        public async Task<IEnumerable<EventOrganizer>> GetAllAsync(CancellationToken token = default)
        {
            return await _eventOrganizerRepository.GetAllAsync(token);
        }

        public async Task<EventOrganizer> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _eventOrganizerRepository.GetAsync(id, token);
        }

        public async Task<bool> UpdateAsync(EventOrganizer eventOrganizer, CancellationToken token = default)
        {
            var eventOrganizerExist = await _eventOrganizerRepository.GetAsync(eventOrganizer.Id, token);

            if (eventOrganizerExist == null)
            {
                return false;
            }

            return await _eventOrganizerRepository.UpdateAsync(eventOrganizer, token);
        }
    }
}
