using Domain.Common.BaseEntities;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class ContactInformationService : IBaseService<ContactInformation>
    {
        private readonly IBaseRepository<ContactInformation> _contactInformationRepository;

        public ContactInformationService(IBaseRepository<ContactInformation> contactInformationRepository)
        {
            _contactInformationRepository = contactInformationRepository;
        }
        public async Task<ContactInformation> CreateAsync(ContactInformation contactInformation, CancellationToken token = default)
        {
            return await _contactInformationRepository.CreateAsync(contactInformation, token);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var contactInformation = await _contactInformationRepository.GetAsync(id);

            if (contactInformation == null)
                return false;

            return await _contactInformationRepository.DeleteAsync(contactInformation, token);
        }

        public async Task<IEnumerable<ContactInformation>> GetAllAsync(CancellationToken token = default)
        {
            return await _contactInformationRepository.GetAllAsync(token);
        }

        public async Task<ContactInformation> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _contactInformationRepository.GetAsync(id, token);
        }

        public async Task<bool> UpdateAsync(ContactInformation contactInformation, CancellationToken token = default)
        {
            var contactInformationExist = await _contactInformationRepository.GetAsync(contactInformation.Id, token);

            if (contactInformationExist == null)
            {
                return false;
            }

            return await _contactInformationRepository.UpdateAsync(contactInformation, token);
        }
    }
}
