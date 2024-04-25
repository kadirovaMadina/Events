using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class ParticipantService : IBaseService<Participant>
    {
        private readonly IBaseRepository<Participant> _participantRepository;

        public ParticipantService(IBaseRepository<Participant> participantRepository)
        {
            _participantRepository = participantRepository;
        }
        public async Task<Participant> CreateAsync(Participant participant, CancellationToken token = default)
        {
            return await _participantRepository.CreateAsync(participant, token);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var participant = await _participantRepository.GetAsync(id);

            if (participant == null)
                return false;

            return await _participantRepository.DeleteAsync(participant, token);
        }

        public async Task<IEnumerable<Participant>> GetAllAsync(CancellationToken token = default)
        {
            return await _participantRepository.GetAllAsync(token);
        }

        public async Task<Participant> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _participantRepository.GetAsync(id, token);
        }

        public async Task<bool> UpdateAsync(Participant participant, CancellationToken token = default)
        {
            var participantExist = await _participantRepository.GetAsync(participant.Id, token);

            if (participantExist == null)
            {
                return false;
            }

            return await _participantRepository.UpdateAsync(participant, token);
        }
    }
}
