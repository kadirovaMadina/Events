using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class SponsorService : IBaseService<Sponsor>
    {
        private readonly IBaseRepository<Sponsor> _sponsorRepository;

        public SponsorService(IBaseRepository<Sponsor> sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }
        public async Task<Sponsor> CreateAsync(Sponsor sponsor, CancellationToken token = default)
        {
            return await _sponsorRepository.CreateAsync(sponsor, token);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var sponsor = await _sponsorRepository.GetAsync(id);

            if (sponsor == null)
                return false;

            return await _sponsorRepository.DeleteAsync(sponsor, token);
        }

        public async Task<IEnumerable<Sponsor>> GetAllAsync(CancellationToken token = default)
        {
            return await _sponsorRepository.GetAllAsync(token);
        }

        public async Task<Sponsor> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _sponsorRepository.GetAsync(id, token);
        }

        public async Task<bool> UpdateAsync(Sponsor sponsor, CancellationToken token = default)
        {
            var sponsorExist = await _sponsorRepository.GetAsync(sponsor.Id, token);

            if (sponsorExist == null)
            {
                return false;
            }

            return await _sponsorRepository.UpdateAsync(sponsor, token);
        }
    }
}
