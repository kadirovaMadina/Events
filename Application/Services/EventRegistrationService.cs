using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class EventRegistrationService : IBaseService<EventRegistration>
    {
        private readonly IBaseRepository<EventRegistration> _eventRegistrationRepository;

        public EventRegistrationService(IBaseRepository<EventRegistration> eventRegistrationRepository)
        {
            _eventRegistrationRepository = eventRegistrationRepository;
        }
        public async Task<EventRegistration> CreateAsync(EventRegistration eventRegistration, CancellationToken token = default)
        {
            return await _eventRegistrationRepository.CreateAsync(eventRegistration, token);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var eventRegistration = await _eventRegistrationRepository.GetAsync(id);

            if (eventRegistration == null)
                return false;

            return await _eventRegistrationRepository.DeleteAsync(eventRegistration, token);
        }

        public async Task<IEnumerable<EventRegistration>> GetAllAsync(CancellationToken token = default)
        {
            return await _eventRegistrationRepository.GetAllAsync(token);
        }

        public async Task<EventRegistration> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _eventRegistrationRepository.GetAsync(id, token);
        }

        public async Task<bool> UpdateAsync(EventRegistration eventRegistration, CancellationToken token = default)
        {
            var eventRegistrationExist = await _eventRegistrationRepository.GetAsync(eventRegistration.Id, token);

            if (eventRegistrationExist == null)
            {
                return false;
            }

            return await _eventRegistrationRepository.UpdateAsync(eventRegistration, token);
        }
    }
}
