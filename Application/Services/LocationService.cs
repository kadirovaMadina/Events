using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class LocationService : IBaseService<Location>
    {
        private readonly IBaseRepository<Location> _locationRepository;

        public LocationService(IBaseRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public async Task<Location> CreateAsync(Location location, CancellationToken token = default)
        {
            return await _locationRepository.CreateAsync(location, token);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var location = await _locationRepository.GetAsync(id);

            if (location == null)
                return false;

            return await _locationRepository.DeleteAsync(location, token);
        }

        public async Task<IEnumerable<Location>> GetAllAsync(CancellationToken token = default)
        {
            return await _locationRepository.GetAllAsync(token);
        }

        public async Task<Location> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _locationRepository.GetAsync(id, token);
        }

        public async Task<bool> UpdateAsync(Location location, CancellationToken token = default)
        {
            var locationExist = await _locationRepository.GetAsync(location.Id, token);

            if (locationExist == null)
            {
                return false;
            }

            return await _locationRepository.UpdateAsync(location, token);
        }
    }
}
