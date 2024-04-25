namespace Application.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(Guid id, CancellationToken token = default);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token = default);
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken token = default);
        Task<bool> UpdateAsync(TEntity entity, CancellationToken token = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken token = default);
        //Task GetAsync(int id);
    }
}
