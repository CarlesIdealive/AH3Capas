namespace DomainComponent.Interfaces
{
    public interface ICommonRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity item);

    }
}
