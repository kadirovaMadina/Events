using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class SpeakerService : IBaseService<Speaker>
    {
        private readonly IBaseRepository<Speaker> _speakerRepository;

        public SpeakerService(IBaseRepository<Speaker> speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }
        public async Task<Speaker> CreateAsync(Speaker speaker, CancellationToken token = default)
        {
            return await _speakerRepository.CreateAsync(speaker, token);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var speaker = await _speakerRepository.GetAsync(id);

            if (speaker == null)
                return false;

            return await _speakerRepository.DeleteAsync(speaker, token);
        }

        public async Task<IEnumerable<Speaker>> GetAllAsync(CancellationToken token = default)
        {
            return await _speakerRepository.GetAllAsync(token);
        }

        public async Task<Speaker> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _speakerRepository.GetAsync(id, token);
        }

        public async Task<bool> UpdateAsync(Speaker speaker, CancellationToken token = default)
        {
            var speakerExist = await _speakerRepository.GetAsync(speaker.Id, token);

            if (speakerExist == null)
            {
                return false;
            }

            return await _speakerRepository.UpdateAsync(speaker, token);
        }
    }
}
