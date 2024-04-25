using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class OrganizerService : IBaseService<Organizer>
    {
        private readonly IBaseRepository<Organizer> _organizerRepository;

        public OrganizerService(IBaseRepository<Organizer> organizerRepository)
        {
            _organizerRepository = organizerRepository;
        }
        public async Task<Organizer> CreateAsync(Organizer organizer, CancellationToken token = default)
        {
            return await _organizerRepository.CreateAsync(organizer, token);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var organizer = await _organizerRepository.GetAsync(id);

            if (organizer == null)
                return false;

            return await _organizerRepository.DeleteAsync(organizer, token);
        }

        public async Task<IEnumerable<Organizer>> GetAllAsync(CancellationToken token = default)
        {
            return await _organizerRepository.GetAllAsync(token);
        }

        public async Task<Organizer> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _organizerRepository.GetAsync(id, token);
        }

        public async Task<bool> UpdateAsync(Organizer organizer, CancellationToken token = default)
        {
            var organizerExist = await _organizerRepository.GetAsync(organizer.Id, token);

            if (organizerExist == null)
            {
                return false;
            }

            return await _organizerRepository.UpdateAsync(organizer, token);
        }
    }
}
