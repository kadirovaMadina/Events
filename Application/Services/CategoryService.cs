using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class CategoryService : IBaseService<EventCategory>
    {
        private readonly IBaseRepository<EventCategory> _categoryRepository;

        public CategoryService(IBaseRepository<EventCategory> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<EventCategory> CreateAsync(EventCategory category, CancellationToken token = default)
        {
            return await _categoryRepository.CreateAsync(category, token);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
        {
            var category = await _categoryRepository.GetAsync(id);

            if (category == null)
                return false;

            return await _categoryRepository.DeleteAsync(category, token);
        }

        public async Task<IEnumerable<EventCategory>> GetAllAsync(CancellationToken token = default)
        {
            return await _categoryRepository.GetAllAsync(token);
        }

        public async Task<EventCategory> GetAsync(Guid id, CancellationToken token = default)
        {
            return await _categoryRepository.GetAsync(id, token);
        }

        public async Task<bool> UpdateAsync(EventCategory category, CancellationToken token = default)
        {
            var categoryExist = await _categoryRepository.GetAsync(category.Id, token);

            if (categoryExist == null)
            {
                return false;
            }

            return await _categoryRepository.UpdateAsync(category, token);
        }
    }
}
