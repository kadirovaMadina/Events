using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class EventService : IBaseService<Event>
    {
        private readonly IBaseRepository<Event> _eventRepository;

        public EventService(IBaseRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<Event> CreateAsync(Event @event, CancellationToken token = default)
        {
            return await _eventRepository.CreateAsync(@event, token);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var @event = await _eventRepository.GetAsync(id);

            if (@event == null)
                return false;

            return await _eventRepository.DeleteAsync(@event, token);
        }

        public async Task<IEnumerable<Event>> GetAllAsync(CancellationToken token = default)
        {
            return await _eventRepository.GetAllAsync(token);
        }

        public async Task<Event> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _eventRepository.GetAsync(id, token);
        }

        public async Task<bool> UpdateAsync(Event @event, CancellationToken token = default)
        {
            var eventExist = await _eventRepository.GetAsync(@event.Id, token);

            if (eventExist == null)
            {
                return false;
            }

            return await _eventRepository.UpdateAsync(@event, token);
        }
    }

}
